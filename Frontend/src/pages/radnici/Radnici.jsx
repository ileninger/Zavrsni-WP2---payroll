import { useEffect, useState } from "react";
import { Container, Table } from "react-bootstrap";
import RadnikService from "../../services/RadnikService";
import { Link } from "react-router-dom";
import { FaAddressCard } from "react-icons/fa";
//import { FaEdit } from "react-icons/fa";
import { FaUserEdit } from "react-icons/fa";
import { FaUserMinus } from "react-icons/fa6";

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
            <FaAddressCard 
                size='30'
            />
                 Dodaj novog ranika
            </Link>
            <Table striped bordered hover responsive className="table">
                <thead>
                    <tr>
                        <th>Ime</th>
                        <th>Prezime</th>
                        <th className="sredina">OiB</th>
                        <th className="sredina">Datumzaposlenja</th>
                        <th className="sredina">IBAN</th>
                        <th className="sredina"></th>
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
                            <td className="sredina">
                                <Link>
                                    <FaUserEdit size={25}/>
                                </Link>
                                &nbsp;&nbsp;&nbsp;
                                <Link>
                                    <FaUserMinus size={25}/>
                                </Link>

                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>



    );
}