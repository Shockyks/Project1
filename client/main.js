import { Aerodrom } from "./aerodrom.js";
import { Let } from "./let.js";

var listaAerodroma=[];

fetch("https://localhost:5001/Aerodrom/PronadjiAerodrome")
.then(p=>{
    p.json().then(aerodromi=>{
        aerodromi.forEach(aerodrom=>{
            var p = new Aerodrom(aerodrom.id, aerodrom.naziv, aerodrom.grad, aerodrom.drzava)
            listaAerodroma.push(p);
        })
        var f = new Let(listaAerodroma);
        f.crtaj(document.body);
    })
})

