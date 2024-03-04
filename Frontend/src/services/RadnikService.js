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

export default{
    getRadnici
};