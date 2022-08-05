import "./App.css";
import { Route, Routes } from "react-router-dom";
import { AuthProvider } from './contexts/AuthContext';
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
import Favorite from "./components/Favorite/Favorite";
import PrivateRoute from "./components/Common/PrivateRoute";
import GuardedRoute from "./components/Common/GuardedRoute";

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
        <Route path="/my-recipes" element={<PrivateRoute><RecipesList /></PrivateRoute>} />
        <Route path="/favorite" element={<PrivateRoute><Favorite /></PrivateRoute>} />
        <Route path="/details/:id" element={<Details/>}></Route>
        <Route element={<GuardedRoute />}>
          <Route path="/all" element={<RecipesList/>}></Route>
          <Route path="/add" element={<Create/>}></Route>
          <Route path="/edit/:id" element={<Edit/>}></Route>
        </Route>
      </Routes>
      <Footer />
    </div>
    </AuthProvider>
  );
}

export default App;
