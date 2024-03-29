﻿namespace MiBo.Domain.Common.Constants
{
    public static class Logics
    {
        // Description for common
        public const string TEXT_BLANK = "";
        public const string LOCALE_DEFAULT = "vi-VN";
        public const string PASSWORD_DEFAULT = "mibovn";

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
        public const string PR_DISCOUNT_MEMBER = "001";
        public const string PR_HOTLINE = "002";
        public const string PR_ADDRESS = "003";
        public const string PR_CHAT_YAHOO = "004";
        public const string PR_CHAT_SKYPE = "005";
        public const string PR_EMAIL_INFO = "006";
        public const string PR_EMAIL_INFO_PASS = "007";
        public const string PR_EMAIL_SALE = "008";
        public const string PR_EMAIL_SALE_PASS = "009";
        public const string PR_EMAIL_SUPPORT = "010";
        public const string PR_EMAIL_SUPPORT_PASS = "011";
        public const string PR_MAIL_SERVER = "012";

        // Description for group code
        public const string GROUP_SKIP_CODE = "sys-skip-code";
        public const string GROUP_DELETE_FLAG = "sys-delete-flag";
        public const string GROUP_ITEM_DIV = "sys-item-div";
        public const string GROUP_CATEGORY_DIV = "sys-category-div";
        public const string GROUP_PRICE_DIV = "sys-price-div";
        public const string GROUP_SLIP_STATUS = "sys-slip-status";
        public const string GROUP_GIFT_STATUS = "sys-gift-status";
        public const string GROUP_PAYMENT_METHODS = "sys-payment-methods";
        public const string GROUP_OFFER_DIV = "sys-offer-div";

        // Description for master code
        public const string CD_ITEM_DIV_NONE = "01";
        public const string CD_ITEM_DIV_NEW = "02";
        public const string CD_OFFER_DIV_DISCOUNT = "01";
        public const string CD_OFFER_DIV_ITEM = "02";
        public const string CD_PRICE_DIV_MORE = "03";
        public const string CD_CATEGORY_DIV_TOYS = "01";
        public const string CD_CATEGORY_DIV_LEARNING_TOOLS = "02";
        public const string CD_CATEGORY_DIV_BOOKS = "03";

        public const string CD_GIFT_STATUS_INACTIVE = "01";
        public const string CD_GIFT_STATUS_ACTIVE = "02";
        public const string CD_GIFT_STATUS_USED = "03";

        // Description for business code
        public const string CD_BUSINESS_ACCEPT = "01";

        // Description for show code
        public const string CD_SHOW_ITEMS_SEARCH = "search";
        public const string CD_SHOW_ITEMS_OFFER = "offer";
        public const string CD_SHOW_ITEMS_NEW = "new";
        public const string CD_SHOW_ITEMS_HOT = "hot";
        public const string CD_SHOW_ITEMS_GROUP = "group";

        // Description for group user
        public const string GP_ADMINISTRATORS = "administrators";
        public const string GP_STAFFSELLERS = "staffsellers";
        public const string GP_USERS = "users";

        // Description for roles
        public const string RL_USERS = "role-users";
        public const string RL_ACCEPTS = "role-accepts";
        public const string RL_ITEMS = "role-items";
        public const string RL_BRANDS = "role-brands";
        public const string RL_CATEGORIES = "role-categories";
        public const string RL_GIFTS = "role-gifts";
        public const string RL_GIFT_ENTRY = "role-gift-entry";
        public const string RL_SYSTEMS = "role-systems";
        public const string RL_OFFERS = "role-offers";
        public const string RL_BANNERS = "role-banners";
    }
}