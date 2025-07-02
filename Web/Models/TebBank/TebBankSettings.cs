using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.TebBank
{
    /// <summary>
    /// TEB Bank configuration settings (non-sensitive data)
    /// </summary>
    public class TebBankSettings
    {
        [Required]
        [Url]
        public string PostUrl { get; set; } = "https://ecommerce.teb-kos.com/fim/est3Dgate";

        [Required]
        [Url]
        public string ApiUrl { get; set; } = "https://ecommerce.teb-kos.com/fim/api";

        [Required]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Currency must be a 3-digit ISO code")]
        public string Currency { get; set; } = "978"; // EUR currency code

        [Required]
        [RegularExpression(@"^(en|tr|al)$", ErrorMessage = "Language must be en, tr, or al")]
        public string Language { get; set; } = "en";

        [Required]
        [RegularExpression(@"^(Auth|PreAuth|PostAuth|Credit|Void)$")]
        public string TransactionType { get; set; } = "Auth";

        [Required]
        public string StoreType { get; set; } = "3d_pay_hosting";

        [Required]
        public string HashAlgorithm { get; set; } = "ver3";

        [Required]
        [Range(1, 60)]
        public string RefreshTime { get; set; } = "10";

        [Range(5, 60)]
        public int SessionTimeoutMinutes { get; set; } = 15;

        [Range(0.01, 1000000)]
        public decimal MaxAmount { get; set; } = 10000;

        [Range(0.01, 100)]
        public decimal MinAmount { get; set; } = 1;

        /// <summary>
        /// Installment options for hosted payment page
        /// </summary>
        public string InstallmentOptions { get; set; } = "";

        /// <summary>
        /// Default currency symbol for display
        /// </summary>
        public string CurrencySymbol => Currency switch
        {
            "978" => "€", // EUR
            "949" => "₺", // TRY
            "840" => "$", // USD
            _ => "€"
        };

        /// <summary>
        /// Get currency name
        /// </summary>
        public string CurrencyName => Currency switch
        {
            "978" => "Euro",
            "949" => "Turkish Lira",
            "840" => "US Dollar",
            _ => "Euro"
        };

        /// <summary>
        /// Validate settings
        /// </summary>
        public bool IsValid()
        {
            return !string.IsNullOrEmpty(PostUrl) &&
                   !string.IsNullOrEmpty(ApiUrl) &&
                   !string.IsNullOrEmpty(Currency) &&
                   !string.IsNullOrEmpty(Language) &&
                   !string.IsNullOrEmpty(TransactionType) &&
                   MaxAmount > MinAmount &&
                   SessionTimeoutMinutes > 0;
        }
    }

    /// <summary>
    /// TEB Bank credentials (sensitive data - loaded from environment/secrets)
    /// </summary>
    public class TebBankCredentials
    {
        [Required]
        public string ClientId { get; set; } = "";

        [Required]
        public string UserName { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";

        [Required]
        public string StoreKey { get; set; } = "";

        [Required]
        public string ApiUserName { get; set; } = "";

        [Required]
        public string ApiPassword { get; set; } = "";

        /// <summary>
        /// Validate that all required credentials are present
        /// </summary>
        public bool IsComplete()
        {
            return !string.IsNullOrWhiteSpace(ClientId) &&
                   !string.IsNullOrWhiteSpace(UserName) &&
                   !string.IsNullOrWhiteSpace(Password) &&
                   !string.IsNullOrWhiteSpace(StoreKey) &&
                   !string.IsNullOrWhiteSpace(ApiUserName) &&
                   !string.IsNullOrWhiteSpace(ApiPassword);
        }

        /// <summary>
        /// Clear all credential values (for security)
        /// </summary>
        public void Clear()
        {
            ClientId = "";
            UserName = "";
            Password = "";
            StoreKey = "";
            ApiUserName = "";
            ApiPassword = "";
        }
    }
}

namespace Web.Models.Payment
{
    /// <summary>
    /// Payment session for tracking payment requests securely
    /// </summary>
    public class PaymentSession
    {
        [Required]
        public string Token { get; set; } = "";

        [Required]
        public string OrderId { get; set; } = "";

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public string UserId { get; set; } = "";

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime ExpiresAt { get; set; }

        public PaymentSessionStatus Status { get; set; } = PaymentSessionStatus.Active;

        public string? TransactionId { get; set; }

        public string? BankReference { get; set; }

        public string? ErrorMessage { get; set; }

        public string? IPAddress { get; set; }

        public string? UserAgent { get; set; }

        /// <summary>
        /// Additional metadata for the payment session
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; } = new();

        /// <summary>
        /// Check if the session has expired
        /// </summary>
        public bool IsExpired => DateTime.UtcNow > ExpiresAt || Status == PaymentSessionStatus.Expired;

        /// <summary>
        /// Check if the session is still valid for processing
        /// </summary>
        public bool IsValid => !IsExpired && Status == PaymentSessionStatus.Active;

        /// <summary>
        /// Mark session as expired
        /// </summary>
        public void MarkAsExpired()
        {
            Status = PaymentSessionStatus.Expired;
        }

        /// <summary>
        /// Mark session as completed successfully
        /// </summary>
        public void MarkAsCompleted(string transactionId, string? bankReference = null)
        {
            Status = PaymentSessionStatus.Completed;
            TransactionId = transactionId;
            BankReference = bankReference;
        }

        /// <summary>
        /// Mark session as failed
        /// </summary>
        public void MarkAsFailed(string errorMessage)
        {
            Status = PaymentSessionStatus.Failed;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Create a new payment session
        /// </summary>
        public static PaymentSession Create(string token, string orderId, decimal amount, string userId, int timeoutMinutes = 15)
        {
            return new PaymentSession
            {
                Token = token,
                OrderId = orderId,
                Amount = amount,
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddMinutes(timeoutMinutes),
                Status = PaymentSessionStatus.Active
            };
        }

        /// <summary>
        /// Validate session for specific order and amount
        /// </summary>
        public bool ValidateForPayment(string orderId, decimal amount, decimal tolerance = 0.01m)
        {
            return IsValid &&
                   OrderId.Equals(orderId, StringComparison.OrdinalIgnoreCase) &&
                   Math.Abs(Amount - amount) <= tolerance;
        }
    }

    /// <summary>
    /// Payment session status enumeration
    /// </summary>
    public enum PaymentSessionStatus
    {
        /// <summary>
        /// Session is active and can be used for payment
        /// </summary>
        Active = 0,

        /// <summary>
        /// Payment completed successfully
        /// </summary>
        Completed = 1,

        /// <summary>
        /// Payment failed
        /// </summary>
        Failed = 2,

        /// <summary>
        /// Session expired
        /// </summary>
        Expired = 3,

        /// <summary>
        /// Session cancelled by user
        /// </summary>
        Cancelled = 4,

        /// <summary>
        /// Session is being processed
        /// </summary>
        Processing = 5
    }

    /// <summary>
    /// Payment initiation request model
    /// </summary>
    public class PaymentInitiationRequest
    {
        [Required(ErrorMessage = "Order ID is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Order ID must be between 1 and 50 characters")]
        public string OrderId { get; set; } = "";

        [Required(ErrorMessage = "Amount is required")]
        [Range(0.01, 100000, ErrorMessage = "Amount must be between 0.01 and 100,000")]
        public decimal Amount { get; set; }

        [StringLength(100, ErrorMessage = "Customer name cannot exceed 100 characters")]
        public string? CustomerName { get; set; }

        [StringLength(100, ErrorMessage = "Customer company cannot exceed 100 characters")]
        public string? CustomerCompany { get; set; }

        [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters")]
        public string? Description { get; set; }

        /// <summary>
        /// Return URL after successful payment (optional - will use default if not provided)
        /// </summary>
        [Url(ErrorMessage = "Return URL must be a valid URL")]
        public string? ReturnUrl { get; set; }

        /// <summary>
        /// Cancel URL after failed/cancelled payment (optional - will use default if not provided)
        /// </summary>
        [Url(ErrorMessage = "Cancel URL must be a valid URL")]
        public string? CancelUrl { get; set; }

        /// <summary>
        /// Additional metadata for the payment
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; } = new();

        /// <summary>
        /// Validate the request
        /// </summary>
        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(OrderId) &&
                   Amount > 0 &&
                   OrderId.Length <= 50 &&
                   (string.IsNullOrEmpty(CustomerName) || CustomerName.Length <= 100) &&
                   (string.IsNullOrEmpty(CustomerCompany) || CustomerCompany.Length <= 100);
        }
    }

    /// <summary>
    /// Order model for payment processing
    /// </summary>
    public class OrderModel
    {
        public string OrderId { get; set; } = "";
        public decimal Amount { get; set; }
        public OrderStatus Status { get; set; }
        public string CustomerName { get; set; } = "";
        public string CustomerCompany { get; set; } = "";
        public string CustomerEmail { get; set; } = "";
        public string CustomerPhone { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? PaidAt { get; set; }
        public string? TransactionId { get; set; }
        public string? PaymentReference { get; set; }
        public string UserId { get; set; } = "";

        /// <summary>
        /// Check if order can be paid
        /// </summary>
        public bool CanBePaid => Status == OrderStatus.Pending && Amount > 0;

        /// <summary>
        /// Mark order as paid
        /// </summary>
        public void MarkAsPaid(string transactionId, string? paymentReference = null)
        {
            Status = OrderStatus.Paid;
            PaidAt = DateTime.UtcNow;
            TransactionId = transactionId;
            PaymentReference = paymentReference;
        }

        /// <summary>
        /// Mark order as failed
        /// </summary>
        public void MarkAsFailed()
        {
            Status = OrderStatus.Failed;
        }
    }

    /// <summary>
    /// Order status enumeration
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// Order created, waiting for payment
        /// </summary>
        Pending = 0,

        /// <summary>
        /// Payment completed successfully
        /// </summary>
        Paid = 1,

        /// <summary>
        /// Order cancelled
        /// </summary>
        Cancelled = 2,

        /// <summary>
        /// Payment failed
        /// </summary>
        Failed = 3,

        /// <summary>
        /// Order refunded
        /// </summary>
        Refunded = 4,

        /// <summary>
        /// Partial refund applied
        /// </summary>
        PartiallyRefunded = 5
    }
}