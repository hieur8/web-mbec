namespace MiBo.Domain.Common.Constants
{
    public static class Logics
    {
        // Description for common
        public const string TEXT_BLANK = "";
        public const string LOCALE_DEFAULT = "vi-VN";

        // Description for delimiter
        public const char DELIMITER_SKIP_CODE = ',';
        public const string DELIMITER_COLON = ":";
        public const string DELIMITER_COMMA = ",";
        public const string DELIMITER_FORWARD_SLASH = "/";

        // Description for parameter type
        public const string PT_STRING = "String";
        public const string PT_NUMBER = "Number";
        public const string PT_DATE = "Date";
        public const string PT_PASSWORD = "Password";

        // Description for status
        public const string CODE_STATUS_ADD = "add";
        public const string CODE_STATUS_EDIT = "edit";

        // Description for Image Size
        public const string URL_IMAGE_SMALL = "small\\";
        public const string URL_IMAGE_NORMAL = "normal\\";
        public const string URL_IMAGE_LARGER = "larger\\";

        // Description for master parameter
        public const string PR_DISCOUNT_MEMBER = "01";
        public const string PR_EMAIL_INFO = "02";
        public const string PR_EMAIL_INFO_PASS = "03";
        public const string PR_EMAIL_SALE = "04";
        public const string PR_EMAIL_SALE_PASS = "05";
        public const string PR_CHAT_YAHOO = "06";
        public const string PR_CHAT_SKYPE = "07";

        // Description for group code
        public const string GROUP_SKIP_CODE = "sys-skip-code";
        public const string GROUP_DELETE_FLAG = "sys-delete-flag";
        public const string GROUP_ITEM_DIV = "sys-item-div";
        public const string GROUP_PRICE_DIV = "sys-price-div";
        public const string GROUP_SLIP_STATUS = "sys-slip-status";
        public const string GROUP_PAYMENT_METHODS = "sys-payment-methods";

        // Description for master code
        public const string CD_ITEM_DIV_NONE = "01";
        public const string CD_ITEM_DIV_NEW = "02";
        public const string CD_OFFER_DIV_DISCOUNT = "01";
        public const string CD_OFFER_DIV_ITEM = "02";
        public const string CD_PRICE_DIV_MORE = "03";
        public const string CD_CATEGORY_DIV_TOYS = "01";
        public const string CD_CATEGORY_DIV_ACCESSORIES = "02";

        // Description for business code
        public const string CD_BUSINESS_ACCEPT = "01";

        // Description for show code
        public const string CD_SHOW_ITEMS_SEARCH = "search";
        public const string CD_SHOW_ITEMS_OFFER = "offer";
        public const string CD_SHOW_ITEMS_NEW = "new";
        public const string CD_SHOW_ITEMS_HOT = "hot";

        // Description for extension
        public const string EXT_JPEG = "*.jpg";

        // Description for path upload
        public const string PATH_IMG_ITEM = "\\pages\\media\\images\\items\\{0}\\";
    }
}