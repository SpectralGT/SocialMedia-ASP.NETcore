import { useState } from "react";
import "./HomeScreen.css";

type data = {
  title: string;
  content: string;
};

const HomeScreen = () => {
  const [state, setState] = useState<data[]>([]);
  let loaded = false;

  const req = fetch("https://localhost:7205/api/Posts")
    .then((res) => {
      if (!res.ok) {
        throw new Error(res.statusText);
      } else return res.json();
    })
    .then((json) => {
      console.log(json);
      setState(json);
      loaded = true;
      return json;
    });

  return <div>{state.toString()}</div>;
};

export default HomeScreen;
