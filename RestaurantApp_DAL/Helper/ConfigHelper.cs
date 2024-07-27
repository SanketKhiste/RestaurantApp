using System;
using System.IO;
using Microsoft.Extensions.Configuration;

public class ConfigHelper
{
    private readonly IConfiguration _configuration;

    public ConfigHelper()
    {
        IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddJsonFile("appsettings." + Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") + ".json", optional: true);
        _configuration = configurationBuilder.Build();
    }

    public string GetString(string key)
    {
        return GetString(key, string.Empty);
    }

    public string GetString(string key, string defaultValue)
    {
        if (_configuration[key] == null)
        {
            return defaultValue;
        }
        return _configuration[key];
    }

    public int GetInt32(string key)
    {
        return GetInt32(key, 0);
    }

    public int GetInt32(string key, int defaultValue)
    {
        if (_configuration[key] == null)
        {
            return defaultValue;
        }
        return int.Parse(_configuration[key]);
    }

    public double GetDouble(string key)
    {
        return GetDouble(key, 0.0);
    }

    public double GetDouble(string key, double defaultValue)
    {
        if (_configuration[key] == null)
        {
            return defaultValue;
        }
        return double.Parse(_configuration[key]);
    }

    public bool GetBoolean(string key)
    {
        return GetBoolean(key, defaultValue: false);
    }

    public bool GetBoolean(string key, bool defaultValue)
    {
        if (_configuration[key] == null)
        {
            return defaultValue;
        }
        return bool.Parse(_configuration[key].ToLower());
    }

    public string GetConnectionString(string key)
    {
        return GetConnectionString(key, string.Empty);
    }

    public string GetConnectionString(string key, string defaultValue)
    {
        if (_configuration.GetConnectionString(key) == null)
        {
            return defaultValue;
        }
        return _configuration.GetConnectionString(key);
    }

    public static string GetTimeAgo(DateTime dt)
    {
        TimeSpan timeSpan = DateTime.Now - dt;
        if (timeSpan.Days > 365)
        {
            int num = timeSpan.Days / 365;
            if (timeSpan.Days % 365 != 0)
            {
                num++;
            }
            return string.Format("{0} {1} ago", num, (num == 1) ? "year" : "years");
        }
        if (timeSpan.Days > 30)
        {
            int num2 = timeSpan.Days / 30;
            if (timeSpan.Days % 31 != 0)
            {
                num2++;
            }
            return string.Format("{0} {1} ago", num2, (num2 == 1) ? "month" : "months");
        }
        if (timeSpan.Days > 0)
        {
            return string.Format("{0} {1} ago", timeSpan.Days, (timeSpan.Days == 1) ? "day" : "days");
        }
        if (timeSpan.Hours > 0)
        {
            return string.Format("{0} {1} ago", timeSpan.Hours, (timeSpan.Hours == 1) ? "hour" : "hours");
        }
        if (timeSpan.Minutes > 0)
        {
            return string.Format("{0} {1} ago", timeSpan.Minutes, (timeSpan.Minutes == 1) ? "minute" : "minutes");
        }
        if (timeSpan.Seconds > 5)
        {
            return $"{timeSpan.Seconds} seconds ago";
        }
        if (timeSpan.Seconds <= 5)
        {
            return "just now";
        }
        return string.Empty;
    }
}