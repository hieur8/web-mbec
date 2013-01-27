﻿namespace MiBo.Domain.Common.Constants
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

        // Description for master code
        public const string CD_ITEM_DIV_NONE = "01";
        public const string CD_ITEM_DIV_NEW = "02";
        public const string CD_OFFER_DIV_DISCOUNT = "01";
        public const string CD_OFFER_DIV_ITEM = "02";
    }
}