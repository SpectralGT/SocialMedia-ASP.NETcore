﻿using Google.Cloud.Firestore;

namespace webapi.Models
{
    [FirestoreData]
    public class Post
    {
        public string Id { get; set; }

        [FirestoreProperty]
        public string? PostTitle { get; set; } = string.Empty;

        [FirestoreProperty]
        public string Username { get; set; } = string.Empty;

        [FirestoreProperty]
        public Timestamp Date { get; set; }
    }
}
