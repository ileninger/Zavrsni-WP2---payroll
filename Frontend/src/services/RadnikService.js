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


export default{
    getRadnici,
    obrisiRadnika
};