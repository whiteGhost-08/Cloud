﻿using Azure;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using ITableEntity = Azure.Data.Tables.ITableEntity;

namespace ServerlessFunc
{
    public class SessionEntity : ITableEntity
    {
        public const string PartitionKeyName = "SessionEntityPartitionKey";

        public SessionEntity(string name, string sessionId, List<string> tests)
        {
            PartitionKey = PartitionKeyName;
            RowKey = Guid.NewGuid().ToString();
            Id = RowKey;
            SessionId = sessionId;
            HostUserName = name;
            Timestamp = DateTime.Now;
            Tests = tests;
        }

        public SessionEntity() : this(null, null,null) { }

        /// <summary>
        /// To store session Id.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("SessionId")]
        public string SessionId { get; set; }


        /// <summary>
        /// To store Unique id for the entry.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("Id")]
        public string Id { get; set; }


        /// <summary>
        /// To store the host user name.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("HostUserName")]
        public string HostUserName { get; set; }

        [JsonInclude]
        [JsonPropertyName("PartitionKey")]
        public string PartitionKey { get; set; }

        [JsonInclude]
        [JsonPropertyName("RowKey")]
        public string RowKey { get; set; }

        /// <summary>
        /// To store start Timestamp of the session.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("Timestamp")]
        public DateTimeOffset? Timestamp { get; set; }

        /// <summary>
        /// To store the tests done in session
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("Tests")]
        public List<string> Tests { get; set; }

        [JsonIgnore]
        public ETag ETag { get; set; }
    }

    public class SessionRequestData
    {
        public string SessionId { get; set; }
        public List<string> Tests { get; set; }
    }
}