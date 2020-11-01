﻿using System;

namespace TenderPlus.Logger
{
    public interface ILogger
    {
        void Information(string message);
        void Warning(string message);
        void Debug(string message);
        void Error(string message);
        void Error(Exception ex);
        void Error(string message, Exception ex);
    }
}