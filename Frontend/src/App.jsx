import { Route, Routes } from "react-router-dom"
import Pocetna from "./pages/Pocetna"
import { RoutesNames } from "./constants"

function App() {

  return (
    <>
      <Routes>
        <Route path={RoutesNames.HOME} element ={<Pocetna/>} />
      </Routes>
    </>
  )
}

export default App
