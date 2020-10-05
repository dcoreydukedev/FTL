/*************************************************************************
 * Author: DCoreyDuke
 * Originally from DCOreyDuke.CodeBase
 ************************************************************************/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FortyThreeLime.Models.Domain

{
    [Serializable]
    public enum AddressType
    {
        Home,
        Work,
        Business,
        Remote,
        Location,
        Resource,
        Property,
        Service,
        Other,
        Default
    }

    [Serializable]
    public enum Countries
    {
        [Display(Name = "Andorra")]
        AD,

        [Display(Name = "United Arab Emirates")]
        AE,

        [Display(Name = "Afghanistan")]
        AF,

        [Display(Name = "Antigua and Barbuda")]
        AG,

        [Display(Name = "Anguilla")]
        AI,

        [Display(Name = "Albania")]
        AL,

        [Display(Name = "Armenia")]
        AM,

        [Display(Name = "Angola")]
        AO,

        [Display(Name = "Antarctica")]
        AQ,

        [Display(Name = "Argentina")]
        AR,

        [Display(Name = "American Samoa")]
        AS,

        [Display(Name = "Austria")]
        AT,

        [Display(Name = "Australia")]
        AU,

        [Display(Name = "Aruba")]
        AW,

        [Display(Name = "Aland Islands")]
        AX,

        [Display(Name = "Azerbaijan")]
        AZ,

        [Display(Name = "Bosnia and Herzegovina")]
        BA,

        [Display(Name = "Barbados")]
        BB,

        [Display(Name = "Bangladesh")]
        BD,

        [Display(Name = "Belgium")]
        BE,

        [Display(Name = "Burkina Faso")]
        BF,

        [Display(Name = "Bulgaria")]
        BG,

        [Display(Name = "Bahrain")]
        BH,

        [Display(Name = "Burundi")]
        BI,

        [Display(Name = "Benin")]
        BJ,

        [Display(Name = "Saint Barthélemy")]
        BL,

        [Display(Name = "Bermuda")]
        BM,

        [Display(Name = "Brunei Darussalam")]
        BN,

        [Display(Name = "Bolivia, Plurinational State of")]
        BO,

        [Display(Name = "Bonaire, Sint Eustatius and Saba")]
        BQ,

        [Display(Name = "Brazil")]
        BR,

        [Display(Name = "Bahamas")]
        BS,

        [Display(Name = "Bhutan")]
        BT,

        [Display(Name = "Bouvet Island")]
        BV,

        [Display(Name = "Botswana")]
        BW,

        [Display(Name = "Belarus")]
        BY,

        [Display(Name = "Belize")]
        BZ,

        [Display(Name = "Canada")]
        CA,

        [Display(Name = "Cocos (Keeling) Islands")]
        CC,

        [Display(Name = "Congo, the Democratic Republic of the")]
        CD,

        [Display(Name = "Central African Republic")]
        CF,

        [Display(Name = "Congo")]
        CG,

        [Display(Name = "Switzerland")]
        CH,

        [Display(Name = "Côte d'Ivoire")]
        CI,

        [Display(Name = "Cook Islands")]
        CK,

        [Display(Name = "Chile")]
        CL,

        [Display(Name = "Cameroon")]
        CM,

        [Display(Name = "China")]
        CN,

        [Display(Name = "Colombia")]
        CO,

        [Display(Name = "Costa Rica")]
        CR,

        [Display(Name = "Cuba")]
        CU,

        [Display(Name = "Cabo Verde")]
        CV,

        [Display(Name = "Curaçao")]
        CW,

        [Display(Name = "Christmas Island")]
        CX,

        [Display(Name = "Cyprus")]
        CY,

        [Display(Name = "Czech Republic")]
        CZ,

        [Display(Name = "Germany")]
        DE,

        [Display(Name = "Djibouti")]
        DJ,

        [Display(Name = "Denmark")]
        DK,

        [Display(Name = "Dominica")]
        DM,

        [Display(Name = "Dominican Republic")]
        DO,

        [Display(Name = "Algeria")]
        DZ,

        [Display(Name = "Ecuador")]
        EC,

        [Display(Name = "Estonia")]
        EE,

        [Display(Name = "Egypt")]
        EG,

        [Display(Name = "Western Sahara")]
        EH,

        [Display(Name = "Eritrea")]
        ER,

        [Display(Name = "Spain")]
        ES,

        [Display(Name = "Ethiopia")]
        ET,

        [Display(Name = "Finland")]
        FI,

        [Display(Name = "Fiji")]
        FJ,

        [Display(Name = "Falkland Islands (Malvinas)")]
        FK,

        [Display(Name = "Micronesia, Federated States of")]
        FM,

        [Display(Name = "Faroe Islands")]
        FO,

        [Display(Name = "France")]
        FR,

        [Display(Name = "Gabon")]
        GA,

        [Display(Name = "United Kingdom of Great Britain")]
        GB,

        [Display(Name = "Grenada")]
        GD,

        [Display(Name = "Georgia")]
        GE,

        [Display(Name = "French Guiana")]
        GF,

        [Display(Name = "Guernsey")]
        GG,

        [Display(Name = "Ghana")]
        GH,

        [Display(Name = "Gibraltar")]
        GI,

        [Display(Name = "Greenland")]
        GL,

        [Display(Name = "Gambia")]
        GM,

        [Display(Name = "Guinea")]
        GN,

        [Display(Name = "Guadeloupe")]
        GP,

        [Display(Name = "Equatorial Guinea")]
        GQ,

        [Display(Name = "Greece")]
        GR,

        [Display(Name = "South Georgia and the South Sandwich Islands")]
        GS,

        [Display(Name = "Guatemala")]
        GT,

        [Display(Name = "Guam")]
        GU,

        [Display(Name = "Guinea-Bissau")]
        GW,

        [Display(Name = "Guyana")]
        GY,

        [Display(Name = "Hong Kong")]
        HK,

        [Display(Name = "Heard Island and McDonald Islands")]
        HM,

        [Display(Name = "Honduras")]
        HN,

        [Display(Name = "Croatia")]
        HR,

        [Display(Name = "Haiti")]
        HT,

        [Display(Name = "Hungary")]
        HU,

        [Display(Name = "Indonesia")]
        ID,

        [Display(Name = "Ireland")]
        IE,

        [Display(Name = "Israel")]
        IL,

        [Display(Name = "Isle of Man")]
        IM,

        [Display(Name = "India")]
        IN,

        [Display(Name = "British Indian Ocean Territory")]
        IO,

        [Display(Name = "Iraq")]
        IQ,

        [Display(Name = "Iran, Islamic Republic of")]
        IR,

        [Display(Name = "Iceland")]
        IS,

        [Display(Name = "Italy")]
        IT,

        [Display(Name = "Jersey")]
        JE,

        [Display(Name = "Jamaica")]
        JM,

        [Display(Name = "Jordan")]
        JO,

        [Display(Name = "Japan")]
        JP,

        [Display(Name = "Kenya")]
        KE,

        [Display(Name = "Kyrgyzstan")]
        KG,

        [Display(Name = "Cambodia")]
        KH,

        [Display(Name = "Kiribati")]
        KI,

        [Display(Name = "Comoros")]
        KM,

        [Display(Name = "Saint Kitts and Nevis")]
        KN,

        [Display(Name = "Korea, Democratic People's Republic of")]
        KP,

        [Display(Name = "Korea, Republic of")]
        KR,

        [Display(Name = "Kuwait")]
        KW,

        [Display(Name = "Cayman Islands")]
        KY,

        [Display(Name = "Kazakhstan")]
        KZ,

        [Display(Name = "Lao People's Democratic Republic")]
        LA,

        [Display(Name = "Lebanon")]
        LB,

        [Display(Name = "Saint Lucia")]
        LC,

        [Display(Name = "Liechtenstein")]
        LI,

        [Display(Name = "Sri Lanka")]
        LK,

        [Display(Name = "Liberia")]
        LR,

        [Display(Name = "Lesotho")]
        LS,

        [Display(Name = "Lithuania")]
        LT,

        [Display(Name = "Luxembourg")]
        LU,

        [Display(Name = "Latvia")]
        LV,

        [Display(Name = "Libya")]
        LY,

        [Display(Name = "Morocco")]
        MA,

        [Display(Name = "Monaco")]
        MC,

        [Display(Name = "Moldova, Republic of")]
        MD,

        [Display(Name = "Montenegro")]
        ME,

        [Display(Name = "Saint Martin (French part)")]
        MF,

        [Display(Name = "Madagascar")]
        MG,

        [Display(Name = "Marshall Islands")]
        MH,

        [Display(Name = "Macedonia")]
        MK,

        [Display(Name = "Mali")]
        ML,

        [Display(Name = "Myanmar")]
        MM,

        [Display(Name = "Mongolia")]
        MN,

        [Display(Name = "Macao")]
        MO,

        [Display(Name = "Northern Mariana Islands")]
        MP,

        [Display(Name = "Martinique")]
        MQ,

        [Display(Name = "Mauritania")]
        MR,

        [Display(Name = "Montserrat")]
        MS,

        [Display(Name = "Malta")]
        MT,

        [Display(Name = "Mauritius")]
        MU,

        [Display(Name = "Maldives")]
        MV,

        [Display(Name = "Malawi")]
        MW,

        [Display(Name = "Mexico")]
        MX,

        [Display(Name = "Malaysia")]
        MY,

        [Display(Name = "Mozambique")]
        MZ,

        [Display(Name = "Namibia")]
        NA,

        [Display(Name = "New Caledonia")]
        NC,

        [Display(Name = "Niger")]
        NE,

        [Display(Name = "Norfolk Island")]
        NF,

        [Display(Name = "Nigeria")]
        NG,

        [Display(Name = "Nicaragua")]
        NI,

        [Display(Name = "Netherlands")]
        NL,

        [Display(Name = "Norway")]
        NO,

        [Display(Name = "Nepal")]
        NP,

        [Display(Name = "Nauru")]
        NR,

        [Display(Name = "Niue")]
        NU,

        [Display(Name = "New Zealand")]
        NZ,

        [Display(Name = "Oman")]
        OM,

        [Display(Name = "Panama")]
        PA,

        [Display(Name = "Peru")]
        PE,

        [Display(Name = "French Polynesia")]
        PF,

        [Display(Name = "Papua New Guinea")]
        PG,

        [Display(Name = "Philippines")]
        PH,

        [Display(Name = "Pakistan")]
        PK,

        [Display(Name = "Poland")]
        PL,

        [Display(Name = "Saint Pierre and Miquelon")]
        PM,

        [Display(Name = "Pitcairn")]
        PN,

        [Display(Name = "Puerto Rico")]
        PR,

        [Display(Name = "Palestine, State of")]
        PS,

        [Display(Name = "Portugal")]
        PT,

        [Display(Name = "Palau")]
        PW,

        [Display(Name = "Paraguay")]
        PY,

        [Display(Name = "Qatar")]
        QA,

        [Display(Name = "Réunion")]
        RE,

        [Display(Name = "Romania")]
        RO,

        [Display(Name = "Serbia")]
        RS,

        [Display(Name = "Russian Federation")]
        RU,

        [Display(Name = "Rwanda")]
        RW,

        [Display(Name = "Saudi Arabia")]
        SA,

        [Display(Name = "Solomon Islands")]
        SB,

        [Display(Name = "Seychelles")]
        SC,

        [Display(Name = "Sudan")]
        SD,

        [Display(Name = "Sweden")]
        SE,

        [Display(Name = "Singapore")]
        SG,

        [Display(Name = "Saint Helena, Ascension and Tristan da Cunha")]
        SH,

        [Display(Name = "Slovenia")]
        SI,

        [Display(Name = "Svalbard and Jan Mayen")]
        SJ,

        [Display(Name = "Slovakia")]
        SK,

        [Display(Name = "Sierra Leone")]
        SL,

        [Display(Name = "San Marino")]
        SM,

        [Display(Name = "Senegal")]
        SN,

        [Display(Name = "Somalia")]
        SO,

        [Display(Name = "Suriname")]
        SR,

        [Display(Name = "South Sudan")]
        SS,

        [Display(Name = "Sao Tome and Principe")]
        ST,

        [Display(Name = "El Salvador")]
        SV,

        [Display(Name = "Sint Maarten (Dutch part)")]
        SX,

        [Display(Name = "Syrian Arab Republic")]
        SY,

        [Display(Name = "Swaziland")]
        SZ,

        [Display(Name = "Turks and Caicos Islands")]
        TC,

        [Display(Name = "Chad")]
        TD,

        [Display(Name = "French Southern Territories")]
        TF,

        [Display(Name = "Togo")]
        TG,

        [Display(Name = "Thailand")]
        TH,

        [Display(Name = "Tajikistan")]
        TJ,

        [Display(Name = "Tokelau")]
        TK,

        [Display(Name = "Timor-Leste")]
        TL,

        [Display(Name = "Turkmenistan")]
        TM,

        [Display(Name = "Tunisia")]
        TN,

        [Display(Name = "Tonga")]
        TO,

        [Display(Name = "Turkey")]
        TR,

        [Display(Name = "Trinidad and Tobago")]
        TT,

        [Display(Name = "Tuvalu")]
        TV,

        [Display(Name = "Taiwan, Province of China")]
        TW,

        [Display(Name = "Tanzania, United Republic of")]
        TZ,

        [Display(Name = "Ukraine")]
        UA,

        [Display(Name = "Uganda")]
        UG,

        [Display(Name = "United States Minor Outlying Islands")]
        UM,

        [Display(Name = "United States of America")]
        US,

        [Display(Name = "Uruguay")]
        UY,

        [Display(Name = "Uzbekistan")]
        UZ,

        [Display(Name = "Holy See")]
        VA,

        [Display(Name = "Saint Vincent and the Grenadines")]
        VC,

        [Display(Name = "Venezuela, Bolivian Republic of")]
        VE,

        [Display(Name = "Virgin Islands, British")]
        VG,

        [Display(Name = "Virgin Islands, U.S.")]
        VI,

        [Display(Name = "Viet Nam")]
        VN,

        [Display(Name = "Vanuatu")]
        VU,

        [Display(Name = "Wallis and Futuna")]
        WF,

        [Display(Name = "Samoa")]
        WS,

        [Display(Name = "Yemen")]
        YE,

        [Display(Name = "Mayotte")]
        YT,

        [Display(Name = "South Africa")]
        ZA,

        [Display(Name = "Zambia")]
        ZM,

        [Display(Name = "Zimbabwe")]
        ZW
    }

    [Serializable]
    public enum DatabaseType
    {
        MsSql,
        MySql,
        MongoDb,
        SqLite,
        PostGreSq,
        PervasiveSql,
        Oracle,
        Other
    }

    [Serializable]
    public enum Days
    {
        Sunday = 1,
        Monday = 2,
        Tuesday = 3,
        Wednesday = 4,
        Thursday = 5,
        Friday = 6,
        Saturday = 7
    }

    [Serializable]
    public enum EducationLevel
    {
        [Display(Name = "High School or GED")]
        HighSchoolOrGed,

        [Display(Name = "Associates Degree")]
        AssociateDegree,

        [Display(Name = "Bachelor's Degree")]
        FourYearDegree,

        [Display(Name = "Graduate Degree")]
        GraduateDegree,

        [Display(Name = "Other")]
        Other
    }

    [Serializable]
    public enum EmailAddressType
    {
        Main,
        Home,
        Work,
        School,
        Alias,
        Other,
        Default
    }

    [Serializable]
    public enum EmploymentStatus
    {
        [Display(Name = "Employed")]
        Employeed,

        [Display(Name = "Self-Employed")]
        SelfEmployeed,

        [Display(Name = "Retired")]
        Retired,

        [Display(Name = "Student")]
        Student,

        [Display(Name = "Unemployed")]
        Unemployeed
    }

    [Serializable]
    public enum EnvironmentType
    {
        Development,
        Staging,
        Production,
        Testing,
        Sandbox
    }

    [Serializable]
    public enum Gender
    {
        Male = 1,
        Female = 2
    }

    [Serializable]
    public enum HowOftenScale
    {
        VeryOften,
        Often,
        SomewhatOften,
        SomewhatSeldom,
        Seldom,
        VerySeldom
    }

    [Serializable]
    public enum LikelyToRecommendScale
    {
        VeryLikely,
        Likely,
        SomewhatLikely,
        SomewhatUnlikely,
        Unlikely,
        VeryUnlikely
    }

    [Serializable]
    public enum LinkType
    {
        Website,
        Blog,
        Wiki,
        Facebook,
        Twitter,
        Google,
        LinkedIn,
        SnapChat,
        Intagram,
        Pinterest,
        Reddit,
        Repository,
        Other,
        Default
    }

    [Serializable]
    public enum MobilePhoneCarriers
    {
        [Description("AT&T")]
        Att = 35,

        [Description("Boost Mobile")]
        BoostMobile = 1,

        [Description("CREDO Mobile")]
        CredoMobile = 2,

        [Description("Consumer Cellular")]
        ConsumerCellular = 3,

        [Description("Cricket Wireless")]
        CricketWireless = 4,

        [Description("FreeUP Mobile")]
        FreeUpMobile = 5,

        [Description("FreedomPop")]
        FreedomPop = 6,

        [Description("GreatCall")]
        GreatCall = 7,

        [Description("H2O Wireless")]
        H2OWireless = 8,

        [Description("MetroPCS")]
        MetroPcs = 9,

        [Description("Mint Mobile")]
        MintMobile = 10,

        [Description("Net10")]
        NetTen = 11,

        [Description("Page Plus")]
        PagePlus = 12,

        [Description("Project Fi")]
        ProjectFi = 13,

        [Description("Pure TalkUSA")]
        PureTalkUsa = 14,

        [Description("ROK Mobile")]
        RokMobile = 15,

        [Description("Red Pocket")]
        RedPocket = 16,

        [Description("Republic Wireless")]
        RepublicWireless = 17,

        [Description("Simple Mobile")]
        SimpleMobile = 18,

        [Description("Sprint")]
        Sprint = 19,

        [Description("Straight Talk")]
        StraightTalk = 20,

        [Description("T-Mobile")]
        Tmobile = 21,

        [Description("Tello")]
        Tello = 22,

        [Description("TextNow")]
        TextNow = 23,

        [Description("The People's Operator")]
        ThePeoplesOperator = 24,

        [Description("Ting")]
        Ting = 25,

        [Description("Total Wireless")]
        TotalWireless = 26,

        [Description("TracFone")]
        TracFone = 27,

        [Description("Twigby")]
        Twigby = 28,

        [Description("U.S. Cellular")]
        UsCellular = 29,

        [Description("US Mobile")]
        UsMobile = 30,

        [Description("Ultra Mobile")]
        UltraMobile = 31,

        [Description("Verizon Wireless")]
        VerizonWireless = 32,

        [Description("Virgin Mobile")]
        VirginMobile = 33,

        [Description("XFINITY Mobile")]
        XfinityMobile = 34
    }

    [Serializable]
    public enum Months
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }

    [Serializable]
    public enum NameFormat
    {
        FirstNameFirst,
        LastNameFirst
    }

    [Serializable]
    public enum OperatingSytem
    {
        Windows,
        Linux,
        Mac,
        Ios,
        Android,
        Chrome,
        Other
    }

    [Serializable]
    public enum OrderOfImportance
    {
        Primary = 1,
        Secondary = 2,
        Tertiary = 3,
        Quaternary = 4,
        Quinary = 5,
        Senary = 6,
        Septenary = 7,
        Octonary = 8,
        Nonary = 9,
        Denary = 10
    }

    [Serializable]
    public enum PhoneNumberType
    {
        Main = 9,
        Home = 1,
        Business = 2,
        Cell = 3,
        Fax = 4,
        TollFree = 5,
        Other = 6,
        Work = 7,
        Default = 8
    }

    [Serializable]
    public enum Race
    {
        White,
        WhiteNonHispanic,
        Black,
        Latino,
        Asian,
        AsianPacificIslander,
        Other
    }

    [Serializable]
    public enum SatisfactionScale
    {
        VerySatisfied,
        Satisfied,
        SomewhatSatisfied,
        SomewhatUnsatisfied,
        Unsatisfied,
        VeryUnsatisfied
    }

    [Serializable]
    public enum State
    {
        [Description("Alabama")]
        AL = 1,

        [Description("Alaska")]
        AK = 2,

        [Description("Arkansas")]
        AR = 3,

        [Description("Arizona")]
        AZ = 4,

        [Description("California")]
        CA = 5,

        [Description("Colorado")]
        CO = 6,

        [Description("Connecticut")]
        CT = 7,

        [Description("D.C.")]
        DC = 8,

        [Description("Delaware")]
        DE = 9,

        [Description("Florida")]
        FL = 10,

        [Description("Georgia")]
        GA = 11,

        [Description("Hawaii")]
        HI = 12,

        [Description("Iowa")]
        IA = 13,

        [Description("Idaho")]
        ID = 14,

        [Description("Illinois")]
        IL = 15,

        [Description("Indiana")]
        IN = 16,

        [Description("Kansas")]
        KS = 17,

        [Description("Kentucky")]
        KY = 18,

        [Description("Louisiana")]
        LA = 19,

        [Description("Massachusetts")]
        MA = 20,

        [Description("Maryland")]
        MD = 21,

        [Description("Maine")]
        ME = 22,

        [Description("Michigan")]
        MI = 23,

        [Description("Minnesota")]
        MN = 24,

        [Description("Missouri")]
        MO = 25,

        [Description("Mississippi")]
        MS = 26,

        [Description("Montana")]
        MT = 27,

        [Description("North Carolina")]
        NC = 28,

        [Description("North Dakota")]
        ND = 29,

        [Description("Nebraska")]
        NE = 30,

        [Description("New Hampshire")]
        NH = 31,

        [Description("New Jersey")]
        NJ = 32,

        [Description("New Mexico")]
        NM = 33,

        [Description("Nevada")]
        NV = 34,

        [Description("New York")]
        NY = 35,

        [Description("Oklahoma")]
        OK = 36,

        [Description("Ohio")]
        OH = 37,

        [Description("Oregon")]
        OR = 38,

        [Description("Pennsylvania")]
        PA = 39,

        [Description("Rhode Island")]
        RI = 40,

        [Description("South Carolina")]
        SC = 41,

        [Description("South Dakota")]
        SD = 42,

        [Description("Tennessee")]
        TN = 43,

        [Description("Texas")]
        TX = 44,

        [Description("Utah")]
        UT = 45,

        [Description("Virginia")]
        VA = 46,

        [Description("Vermont")]
        VT = 47,

        [Description("Washington")]
        WA = 48,

        [Description("Wisconsin")]
        WI = 49,

        [Description("West Virginia")]
        WV = 50,

        [Description("Wyoming")]
        WY = 51,

        [Description("Guam")]
        GU = 52,

        [Description("Puerto Rico")]
        PR = 53,

        [Description("Virgin Islands")]
        VI = 54
    }
}