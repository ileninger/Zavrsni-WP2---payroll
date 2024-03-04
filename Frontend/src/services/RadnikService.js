import { httpService } from "./httpService";

async function getRadnici (){

    return await httpService.get('/Radnik')
    .then((res)=>{
        console.log(res.data);
        return res;
    }).catch((e)=>{
        console.log(e);
    });

}

export default{
    getRadnici
};