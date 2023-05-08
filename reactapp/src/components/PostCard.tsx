import "./PostCard.css";
import sampleImage from "../assets/sampleImage.jpeg";

function PostCard() {
  return (
    <div className="PostCard">
      <div className="PostHeader">
        <span><img src={sampleImage}/></span>
        <span className="Header-Title">Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet.</span>
      </div>
      <div className="PostContent">
        <img src={sampleImage} alt="image" />
      </div>
    </div>
  );
}
export default PostCard;
