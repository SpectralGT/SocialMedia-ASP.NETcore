using Google.Cloud.Firestore;
using Newtonsoft.Json;
using webapi.Models;

namespace webapi.Providers
{
    public class FirestoreProvider
    {
        string projectId;
        FirestoreDb fireStoreDb;
        public FirestoreProvider()
        {
            string filepath = "C:\\Users\\Atharv Singh\\Downloads\\asp-net-socialmedia-firebase-adminsdk-i7pj9-3801966282.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectId = "asp-net-socialmedia";
            fireStoreDb = FirestoreDb.Create(projectId);
        }
        public async Task<List<Post>> GetAllPost()
        {
            try
            {
                Query PostQuery = fireStoreDb.Collection("Posts");
                QuerySnapshot PostQuerySnapshot = await PostQuery.GetSnapshotAsync();
                List<Post> lstPost = new List<Post>();

                foreach (DocumentSnapshot documentSnapshot in PostQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> post = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(post);
                        Post newpost = JsonConvert.DeserializeObject<Post>(json);
                        newpost.Id = documentSnapshot.Id;
                        newpost.Date = documentSnapshot.CreateTime.Value;
                        lstPost.Add(newpost);
                    }
                }

                List<Post> sortedPostList = lstPost.ToList();
                return sortedPostList;
            }
            catch
            {
                throw;
            }
        }
        public async void AddPost(Post Post)
        {
            try
            {
                CollectionReference colRef = fireStoreDb.Collection("Posts");
                await colRef.AddAsync(Post);
            }
            catch
            {
                throw;
            }
        }
        public async void UpdatePost(Post Post)
        {
            try
            {
                DocumentReference empRef = fireStoreDb.Collection("Posts").Document(Post.Id);
                await empRef.SetAsync(Post, SetOptions.Overwrite);
            }
            catch
            {
                throw;
            }
        }
        public async Task<Post> GetPostData(string id)
        {
            try
            {
                DocumentReference docRef = fireStoreDb.Collection("Posts").Document(id);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    Post emp = snapshot.ConvertTo<Post>();
                    emp.Id = snapshot.Id;
                    return emp;
                }
                else
                {
                    return new Post();
                }
            }
            catch
            {
                throw;
            }
        }
        public async void DeletePost(string id)
        {
            try
            {
                DocumentReference empRef = fireStoreDb.Collection("Posts").Document(id);
                await empRef.DeleteAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<Post>> GetPostData()
        {
            try
            {
                Query citiesQuery = fireStoreDb.Collection("Posts");
                QuerySnapshot citiesQuerySnapshot = await citiesQuery.GetSnapshotAsync();
                List<Post> lstCity = new List<Post>();

                foreach (DocumentSnapshot documentSnapshot in citiesQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> post = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(post);
                        Post newPost = JsonConvert.DeserializeObject<Post>(json);
                        lstCity.Add(newPost);
                    }
                }
                return lstCity;
            }
            catch
            {
                throw;
            }
        }
    }
}