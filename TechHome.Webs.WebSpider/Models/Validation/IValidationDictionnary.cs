﻿using System;

namespace TechHome.Webs.WebSpider.Models.Validation
{
    public interface IValidationDictionary
    {
        void AddError(string key, Exception errorException);
        void AddError(string key, string errorMessage);
        void AddError(Exception errorException);
        void AddError(string errorMessage);
        bool IsValid { get; }
    }
}
