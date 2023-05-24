import "./CreateScreen.css";

function CreateScreen() {
  return (
    <div className="CreateScreen">
      <form  method="POST" action="https://localhost:7205/api/Posts" encType="multipart/form-data">
        <label>Title</label>
        <input type="text" name="Title" />
        <br />
        <label>Image</label>
        <input type="file" accept="image/*" name="Content" />
        <button>upload</button>
      </form>
    </div>
  );
}

export default CreateScreen;
