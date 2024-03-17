import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { RiArrowGoBackFill } from "react-icons/ri"
import { RiArrowGoForwardFill } from "react-icons/ri";
import { RoutesNames } from "../../constants";
import RadnikService from "../../services/RadnikService";


export default function RadniciPomjeni (){
    const navigate = useNavigate();

    async function dodajRadnika(radnik){
        const odgovor = await RadnikService.dodaj(radnik);
        if(odgovor.ok){
          navigate(RoutesNames.RADNICI_PREGLED);
        }else{
          console.log(odgovor);
          alert(odgovor.poruka);
        }
    }
    function handleSubmit(e){
        e.preventDefault();
        const podaci = new FormData(e.target);
        //console.log(podaci.get('naziv'));

        const radnik = 
        {
            ime: podaci.get('ime'),
            prezime: podaci.get('prezime'),
            oiB: podaci.get('oib'),
            datumZaposlenja: podaci.get('datumzaposlenja'),
            iban: podaci.get('iban'),
          };

          //console.log(JSON.stringify(smjer));
          dodajRadnika(radnik);

    }



    // function handleSubmit(e)
    // {
    //     e.preventDefault();
    //     const podaci = new FormData(e.target);
    //     console.log(podaci.get('ime'));

    //     const radnik = 
    //     {
    //         ime: podaci.get('ime'),
    //         prezime: podaci.get('prezime'),
    //         oiB: podaci.get('oib'),
    //         datumZaposlenja: podaci.get('datumzaposlenja'),
    //         iban: podaci.get('iban'),
    //     };

    //     console.log(JSON.stringify(radnik));

    // }

    



    
    return (
        <Container>
            <Form onSubmit={handleSubmit}>
                <Form.Group controlId="ime">
                    <Form.Label>Ime</Form.Label>
                    <Form.Control 
                        type="text"
                        name="ime"/>
                </Form.Group>
                <Form.Group controlId="prezime">
                    <Form.Label>Prezime</Form.Label>
                    <Form.Control 
                        type="text"
                        name="prezime"/>
                </Form.Group>
                <Form.Group controlId="oib">
                    <Form.Label>OiB</Form.Label>
                    <Form.Control 
                        type="text"
                        name="oib"/>
                </Form.Group>
                <Form.Group controlId="datumzaposlenja">
                    <Form.Label>DatumZaposlenja</Form.Label>
                    <Form.Control 
                        type="text"
                        name="datumzaposlenja"/>
                </Form.Group>
                <Form.Group controlId="iban">
                    <Form.Label>Iban</Form.Label>
                    <Form.Control 
                        type="text"
                        name="iban"/>
                </Form.Group>
            <Row className="akcije">
                <Col>
                    <Link 
                        className="btn btn-danger"
                        to={RoutesNames.RADNICI_PREGLED}>
                        <RiArrowGoBackFill size={15} />    
                    Odustani
                    </Link>
                </Col>
                <Col>
                    <Button
                        variant="primary"
                        type="submit">
                        <RiArrowGoForwardFill size ={15} />
                    Dodaj smjer
                    </Button>
                </Col>
            </Row>
            </Form>
         </Container>

    );
}