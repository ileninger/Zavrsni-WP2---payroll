import { useEffect, useState } from "react";
import { Container, Table } from "react-bootstrap";
import RadnikService from "../../services/RadnikService";


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
            <Table striped bordered hover responsive>
                <thead>
                    <tr>
                        <th>Ime</th>
                        <th>Prezime</th>
                        <th>OiB</th>
                        <th>Datumzaposlenja</th>
                        <th>IBAN</th>
                        <th>Akcija</th>
                    </tr>
                </thead>
                <tbody>
                    {radnici && radnici.map((radnik,index)=>(
                        <tr key={index}>
                            <td>{radnik.ime}</td>
                            <td>{radnik.prezime}</td>
                            <td>{radnik.oiB}</td>
                            <td>{radnik.datumZaposlenja}</td>
                            <td>{radnik.iban}</td>
                            <td>AKCIJA</td>

                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>



    );
}