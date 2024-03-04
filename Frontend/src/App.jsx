import { Route, Routes } from "react-router-dom"
import Pocetna from "./pages/Pocetna"

function App() {

  return (
    <>
      <Routes>
        <Route path={'/'} element ={<Pocetna/>} />
      </Routes>
    </>
  )
}

export default App
