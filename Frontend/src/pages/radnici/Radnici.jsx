import { Container, Table } from "react-bootstrap";


export default function Radnici (){

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