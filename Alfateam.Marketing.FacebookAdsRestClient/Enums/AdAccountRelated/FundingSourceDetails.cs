using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum FundingSourceDetails
    {
        [Description("UNSET")]
        Unset = 0,
        [Description("CREDIT_CARD")]
        CreditCard = 1,
        [Description("FACEBOOK_WALLET")]
        FacebookWallet = 2,
        [Description("FACEBOOK_PAID_CREDIT")]
        FacebookPaidCredit = 3,
        [Description("FACEBOOK_EXTENDED_CREDIT")]
        FacebookExtendedCredit = 4,
        [Description("ORDER")]
        Order = 5,
        [Description("INVOICE")]
        Invoice = 6,
        [Description("FACEBOOK_TOKEN")]
        FacebookToken = 7,
        [Description("EXTERNAL_FUNDING")]
        ExternalFunding = 8,
        [Description("FEE")]
        Fee = 9,
        [Description("FX")]
        FX = 10,
        [Description("DISCOUNT")]
        Discount = 11,
        [Description("PAYPAL_TOKEN")]
        PaypalToken = 12,
        [Description("PAYPAL_BILLING_AGREEMENT")]
        PaypalBillingAgreement = 13,
        [Description("FS_NULL")]
        FSNull = 14,
        [Description("EXTERNAL_DEPOSIT")]
        ExternalDeposit = 15,
        [Description("TAX")]
        Tax = 16,
        [Description("DIRECT_DEBIT")]
        DirectDebit = 17,
        [Description("DUMMY")]
        Dummy = 18,
        [Description("ALTPAY")]
        Altpay = 19,
        [Description("STORED_BALANCE")]
        StoredBalance = 20,
    }
}
