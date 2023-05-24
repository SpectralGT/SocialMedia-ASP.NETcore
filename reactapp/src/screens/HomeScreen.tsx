import { useEffect, useState } from "react";
import "./HomeScreen.css";

type data = {
  title: string;
  content: string;
};

const HomeScreen = () => {
  const [state, setState] = useState<data[]>([]);
  let loaded = false;

  const requestData = () => {
    fetch("https://localhost:7205/api/Posts")
      .then((res) => {
        if (!res.ok) {
          throw new Error(res.statusText);
        } else return res.json();
      })
      .then((json) => {
        console.log(json);
        loaded = true;
        setState(json);
        return json;
      });
  };

  useEffect(() => {
    requestData();
  }, []);

  return <div className="homescreen">{
    state.length > 0 && state[0].title}</div>;
};

export default HomeScreen;
