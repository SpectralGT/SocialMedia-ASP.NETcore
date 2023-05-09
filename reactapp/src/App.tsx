import './App.css'
import PostCard from './components/PostCard'



function App() {

  const items = [];

  for(let i=0;i<10;i++){
    items.push(<PostCard key={i} title='dsjkl sdkjf dhs sdji'></PostCard>)
  }

  return (
    <>
    {items}
    </>
  )
}

export default App
