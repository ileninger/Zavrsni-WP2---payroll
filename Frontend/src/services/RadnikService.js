import { App } from "../constants";
import { httpService } from "./httpService";


async function getRadnici (){

    return await httpService.get('/Radnik')
    .then((res)=>{
        if(App.DEV)console.log(res.data);
        return res;
    }).catch((e)=>{
        console.log(e);
    });

}

async function obrisiRadnika (sifra){

    return await httpService.delete('/Radnik/'+sifra)
    .then((res)=>{
        return {ok:true, poruka:res};
    }).catch((e)=>{
        console.log(e);
    });



}
async function dodajRadnika(radnik){
    const odgovor = await httpService.post('Radnik,', radnik)
    .than(()=>{
        return {ok:true,poruka:'Uspješno dodano'}
    })
    .catch((e)=>{
        console.log(e.reponse.data.console.errors);
        return{ok:false,poruka:'Greška'}

    });
    return odgovor;
}

export default{
    getRadnici,
    obrisiRadnika,
    dodajRadnika
};