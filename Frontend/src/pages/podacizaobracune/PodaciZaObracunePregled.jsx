import { useEffect, useState } from "react";
import { Button, Container, Table } from "react-bootstrap";
import RadnikService from "../../services/RadnikService";
import { NumericFormat } from "react-number-format";
import { Link,useNavigate } from "react-router-dom";
import { FaAddressCard, FaSearch } from "react-icons/fa";
//import { FaEdit } from "react-icons/fa";
import { FaUserEdit } from "react-icons/fa";
import { FaUserMinus } from "react-icons/fa6";

import { RoutesNames } from "../../constants";
import moment from "moment/moment";
import PodaciZaObracuneService from "../../services/PodaciZaObracuneService";


export default function PodaciZaObracunePregled (){

    const [podacizaobracune,setPodaciZaObracune] = useState ();
    const navigate = useNavigate();

    async function dohvatiPodatkeZaObracun (){
        await PodaciZaObracuneService.getPodaciZaObracune()
        .then((res)=>{
            setPodaciZaObracune(res.data);
        })
        .catch((e)=>{
            alert(e);
        });
    } 

    async function obrisiRadnika(sifra){

        const odgovor = await PodaciZaObracuneService.obrisiPodatkeZaObracune(sifra);
        if (odgovor.ok){
            alert(odgovor.poruka.data.poruka)
            dohvatiPodatkeZaObracun();
        }

    }

    useEffect(()=>{
        dohvatiPodatkeZaObracun();
    },[]);

    return (
        <Container>
{/* 
                    <Link to={RoutesNames.RADNICI_DODAJ} className="btn gumb">
                    <FaAddressCard 
                        size='30'
                        className="lijevo"
                    />
                        Dodaj novog ranika
                    </Link> */}
        
            <Table striped bordered hover responsive className="table">
                <thead>
                    <tr>

                        <th className="sredina">Porezna osnovica</th>
                        <th className="sredina">Osnovni osobni odbitak</th>
                        <th className="sredina">Udio za prvi mirovinski stup</th>
                        <th className="sredina">Udio za drugi mirovinski stup</th>
                        <th className="sredina">Stopa poreza na dohodak</th>
                        <th className="sredina">Akcija</th>
                    </tr>
                </thead>
                <tbody>
                    {podacizaobracune && podacizaobracune.map((podacizaobracune,index)=>(
                        <tr key={index}>

                            <td className={podacizaobracune.poreznaOsnovica==null ? 'sredina' : 'sredina'}>
                                {podacizaobracune.poreznaOsnovica==null 
                                ? 'Nije definirano'
                                :
                                    <NumericFormat 
                                    value={podacizaobracune.poreznaOsnovica}
                                    displayType={'text'}
                                    thousandSeparator='.'
                                    decimalSeparator=','
                                    prefix={'€'}
                                    decimalScale={2}
                                    fixedDecimalScale
                                    />
                                } 
                            </td>
                            <td className={podacizaobracune.osnovniOsobniOdbitak==null ? 'sredina' : 'sredina'}>
                                {podacizaobracune.osnovniOsobniOdbitak==null 
                                ? 'Nije definirano'
                                :
                                    <NumericFormat 
                                    value={podacizaobracune.osnovniOsobniOdbitak}
                                    displayType={'text'}
                                    thousandSeparator='.'
                                    decimalSeparator=','
                                    prefix={'€'}
                                    decimalScale={2}
                                    fixedDecimalScale
                                    />
                                } 
                            </td>
                            <td className={podacizaobracune.udioZaPrviMirovinskiStup==null ? 'sredina' : 'sredina'}>
                                {podacizaobracune.udioZaPrviMirovinskiStup==null 
                                ? 'Nije definirano'
                                :
                                    <NumericFormat 
                                    value={podacizaobracune.udioZaPrviMirovinskiStup}
                                    displayType={'text'}
                                    thousandSeparator='.'
                                    decimalSeparator=','
                                    suffix={'%'}
                                    decimalScale={2}
                                    fixedDecimalScale
                                    />
                                } 
                            </td>
                            <td className={podacizaobracune.udioZaDrugiMirovinskiStup==null ? 'sredina' : 'sredina'}>
                                {podacizaobracune.udioZaDrugiMirovinskiStup==null 
                                ? 'Nije definirano'
                                :
                                    <NumericFormat 
                                    value={podacizaobracune.udioZaDrugiMirovinskiStup}
                                    displayType={'text'}
                                    thousandSeparator='.'
                                    decimalSeparator=','
                                    suffix={'%'}
                                    decimalScale={2}
                                    fixedDecimalScale
                                    />
                                } 
                            </td>
                            <td className={podacizaobracune.porezNaDohodak==null ? 'sredina' : 'sredina'}>
                                {podacizaobracune.porezNaDohodak==null 
                                ? 'Nije definirano'
                                :
                                    <NumericFormat 
                                    value={podacizaobracune.porezNaDohodak}
                                    displayType={'text'}
                                    thousandSeparator='.'
                                    decimalSeparator=','
                                    suffix={'%'}
                                    decimalScale={2}
                                    fixedDecimalScale
                                    />
                                } 
                            </td>
                            
                            <td className="sredina">
                                <Button
                                    variant="normal"
                                    //</Button></td>onClick={()=>{navigate(`/radnici/${radnik.sifra}`)}}
                                    >
                                    <FaUserEdit 
                                     color="blue"
                                    
                                    size={25} />
                                </Button>
                                     &nbsp;&nbsp;&nbsp;
                                <Button
                                    variant="normal"
                                    //onClick={()=>obrisiRadnika(radnik.sifra)}
                                >
       
                                    <FaUserMinus 
                                    size={25}
                                    color="red" 
                                    />
                                </Button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>
    );
}