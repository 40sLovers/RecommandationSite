import './css//App.css';
import Navbar from './components/navbar';
import {
  Routes,
  Route
} from "react-router-dom";
import Home from './components/Home'
import Profile from './components/Profile'
import Saved from './components/Saved'
import Explore from './components/Explore'

function App() {
  return (
    <div>
      <header>
        <Navbar/>
      </header>
      <section style={{marginTop:"3rem"}}>
        <Routes>
          <Route exact path="/" element={<Home/>}>
          </Route>
          <Route path="/explore"  element={<Explore/>} >
          </Route>
          <Route path="/saved"  element={<Saved/>}>
          </Route>
          <Route path="/profile"  element={<Profile/>}>
          </Route>
        </Routes>
        </section>
    </div>
  );
}

export default App;
