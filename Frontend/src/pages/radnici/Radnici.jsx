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
                        <th>Datum zaposlenja</th>
                        <th>IBAN</th>
                        <th>Akcija</th>
                    </tr>
                </thead>
            </Table>
        </Container>



    );
}