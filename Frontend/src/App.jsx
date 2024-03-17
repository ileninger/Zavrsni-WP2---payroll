import { Route, Routes } from "react-router-dom"
import Pocetna from "./pages/Pocetna"
import { RoutesNames } from "./constants"
import NavBar from "./components/NavBar"
import Radnici from "./pages/radnici/Radnici"

import 'bootstrap/dist/css/bootstrap.min.css'
import './App.css';
import RadniciDodaj from "./pages/radnici/RadniciDodaj"
import RadniciPomjeni from "./pages/radnici/RadniciPomjeni"

function App() {

  return (
    <>
      <NavBar />
      <Routes>
        <Route path={RoutesNames.HOME} element ={<Pocetna/>} />
        <Route path={RoutesNames.RADNICI_PREGLED} element ={<Radnici/>} />
        <Route path={RoutesNames.RADNICI_DODAJ} element ={<RadniciDodaj/>} />
        <Route path={RoutesNames.RADNICI_PROMJENI} element ={<RadniciPomjeni/>} />
      </Routes>
    </>
  )
}

export default App
