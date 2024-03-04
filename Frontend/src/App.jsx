import { Route, Routes } from "react-router-dom"
import Pocetna from "./pages/Pocetna"
import { RoutesNames } from "./constants"
import NavBar from "./components/NavBar"
import Radnici from "./pages/radnici/Radnici"

function App() {

  return (
    <>
      <NavBar />
      <Routes>
        <Route path={RoutesNames.HOME} element ={<Pocetna/>} />
        <Route path={RoutesNames.RADNICI_PREGLED} element ={<Radnici/>} />
      </Routes>
    </>
  )
}

export default App
