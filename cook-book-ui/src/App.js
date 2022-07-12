import { Route, Routes } from "react-router-dom";
import "./App.css";
import Navbar from "./components/Navbar/Navbar";
import Landing from "./components/Landing/Landing";
import Footer from "./components/Footer/Footer";
import RecipesList from "./components/Recipes/RecipesList";
import Login from "./components/Login/Login";
import Register from "./components/Register/Register";
import Logout from "./components/Logout/Logout";

function App() {
  return (
    <div className="App">
      <Navbar />
      <Routes>
        <Route path="/" element={<Landing/>}></Route>
        <Route path="/login" element={<Login/>}></Route>
        <Route path="/sign-up" element={<Register/>}></Route>
        <Route path="/logout" element={<Logout/>}></Route>
        <Route path="/all" element={<RecipesList/>}></Route>
      </Routes>
      <Footer />
    </div>
  );
}

export default App;
