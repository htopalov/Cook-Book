import { Route, Routes } from "react-router-dom";
import "./App.css";
import Navbar from "./components/Navbar/Navbar";
import Landing from "./components/Landing/Landing";
import Footer from "./components/Footer/Footer";
import RecipesList from "./components/Recipes/RecipesList";
import Login from "./components/Login/Login";
import Register from "./components/Register/Register";
import Logout from "./components/Logout/Logout";
import Create from "./components/Create/Create";
import Details from "./components/Details/Details";
import Edit from "./components/Edit/Edit";

import { AuthProvider } from './contexts/AuthContext';

function App() {
  return (
    <AuthProvider>
    <div className="App">
      <Navbar />
      <Routes>
        <Route path="/" element={<Landing/>}></Route>
        <Route path="/login" element={<Login/>}></Route>
        <Route path="/sign-up" element={<Register/>}></Route>
        <Route path="/logout" element={<Logout/>}></Route>
        <Route path="/all" element={<RecipesList/>}></Route>
        <Route path="/my-recipes" element={<RecipesList/>}></Route>
        <Route path="/favourite" element={<RecipesList/>}></Route>
        <Route path="/add" element={<Create/>}></Route>
        <Route path="/details/:id" element={<Details/>}></Route>
        <Route path="/edit" element={<Edit/>}></Route>
      </Routes>
      <Footer />
    </div>
    </AuthProvider>
  );
}

export default App;
