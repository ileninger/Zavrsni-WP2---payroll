import { useEffect, useState } from "react";
import { Container, Table } from "react-bootstrap";
import RadnikService from "../../services/RadnikService";
import { Link } from "react-router-dom";
import { MdPersonAddAlt1 } from "react-icons/md";
import { RoutesNames } from "../../constants";

export default function Radnici (){

    const [radnici,setRadnici] = useState ();

    async function dohvatiRadnike (){
        await RadnikService.getRadnici()
        .then((res)=>{
            setRadnici(res.data);
        })
        .catch((e)=>{
            alert(e);
        });
    } 

    useEffect(()=>{
        dohvatiRadnike();
    },[]);

    return (
        <Container>
            <Link to={RoutesNames.RADNICI_DODAJ} className="btn btn-success gumb">
                <MdPersonAddAlt1 
                size='30'
                />  Dodaj novog ranika
            </Link>
            <Table striped bordered hover responsive className="table">
                <thead>
                    <tr>
                        <th>Ime</th>
                        <th>Prezime</th>
                        <th className="sredina">OiB</th>
                        <th className="sredina">Datumzaposlenja</th>
                        <th className="sredina">IBAN</th>
                        <th className="sredina">Akcija</th>
                    </tr>
                </thead>
                <tbody>
                    {radnici && radnici.map((radnik,index)=>(
                        <tr key={index}>
                            <td className="lijevo">{radnik.ime}</td>
                            <td className="lijevo">{radnik.prezime}</td>
                            <td className="sredina">{radnik.oiB}</td>
                            <td className="sredina">{radnik.datumZaposlenja}</td>
                            <td className="sredina" >{radnik.iban}</td>
                            <td>AKCIJA</td>

                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>



    );
}