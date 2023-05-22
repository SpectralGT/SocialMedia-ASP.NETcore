import "./PostCard.css";
import sampleImage from "../assets/sampleImage.jpeg";

interface Props {
  title: string;
  content: string;
}

function PostCard(props: Props) {
  return (
    <div className="PostCard">
      <div className="PostHeader">
        <span>
          <img src={sampleImage} />
        </span>

        <span className="Header-Title">{props.title}</span>
      </div>

      <div className="PostContent">
        <img src={props.content} alt="image" />
      </div>
    </div>
  );
}
export default PostCard;
