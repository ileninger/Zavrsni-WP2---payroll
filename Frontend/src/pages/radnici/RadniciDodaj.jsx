import { Button, Col, Container, Form, Row, Table } from "react-bootstrap";
import { Link } from "react-router-dom";
import { RiArrowGoBackFill, RiArrowGoForwardFill } from "react-icons/ri";
import { RoutesNames } from "../../constants";



export default function RadniciDodaj (){

    function handleSubmit(e){
        e.preventDedaultU();
        const podaci = new FormData(e.target);
        console.log(podaci.get('ime'));

        const radnik = {

            ime: podaci.get ('ime'),
            prezime: podaci.get('prezime'),
            oiB: podaci.get('oib'),
            datumZaposlenja: podaci.get ('datumzaposljenja'),
            iban: podaci.get('iban')
        };

        console.log(JSON.stringify(radnik));
    }   
    
    return (
        <Container>
           <Form onSubmit={handleSubmit}>
                
                <Form.Group controlId="ime">
                    <Form.Label>Ime</Form.Label>
                    <Form.Control 
                        type="text"
                        name="Ime"        
                    />
                </Form.Group>
                <Form.Group controlId="prezime">
                    <Form.Label>Prezime</Form.Label>
                    <Form.Control 
                        type="text"
                        name="Prezime"                        
                    />
                </Form.Group>

                <Form.Group controlId="oib">
                    <Form.Label>OiB</Form.Label>
                    <Form.Control 
                        type="text"
                        name="Prezime"                        
                    />
                </Form.Group>
                <Form.Group controlId="datumzaposlenja">
                    <Form.Label>Datumzaposlenja</Form.Label>
                    <Form.Control 
                        type="text"
                        name="Prezime"                        
                    />
                </Form.Group>
                <Form.Group controlId="iban">
                    <Form.Label>IBAN</Form.Label>
                    <Form.Control 
                        type="text"
                        name="Prezime"                        
                    />
                </Form.Group>
                <Row className="akcije">
                    <Col>
                        <Link 
                        className="btn  btn-danger"
                        to = {RoutesNames.RADNICI_PREGLED}>
                        <RiArrowGoBackFill 
                        size ={15}
                        />
                        Odustani
                        </Link>
                    </Col>
                    <Col>
                        <Button
                            variant="primary"
                            type="submit"
                        >
                            <RiArrowGoForwardFill
                                size ={15}
                            />
                            Dodaj smjer
                        </Button>
     
                    </Col>
                </Row>
            </Form>
        </Container>



    );
}