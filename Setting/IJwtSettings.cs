﻿namespace TextPlus_BE.Setting
{

    public interface IJwtSettings
    {
        public string? Secret { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
    }

}
