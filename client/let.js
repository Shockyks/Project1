import { Lett } from "./lett.js";
import { Klasa } from "./klasa.js";
export class Let{
    constructor(listaAerodroma){
    this.listaAerodroma=listaAerodroma;
    this.kont=null;
    }

    crtaj(host){
        this.kont = document.createElement("div");
        this.kont.className="GlavniKontejner";
        host.appendChild(this.kont);

        let kontForma = document.createElement("div");
        kontForma.className="Forma";
        this.kont.appendChild(kontForma);
        this.crtajFormu(kontForma);

        let kontDodaj = document.createElement("div");
        kontDodaj.className = "Dodaj";
        this.kont.appendChild(kontDodaj);
        this.crtajDodaj(kontDodaj);

    }

    crtajFormu(host){
        var kontprva = document.createElement("div");
        kontprva.className = "prvakonta";
        host.appendChild(kontprva);

        let l = document.createElement("label");
        l.className = "label1";
        l.innerHTML = "Do kog aerodroma";
        kontprva.appendChild(l);

        let se = document.createElement("select");
        se.className = "klasa1";
        kontprva.appendChild(se);

        let op;
        this.listaAerodroma.forEach(p=>{
            op = document.createElement("option");
            op.innerHTML = p.naziv + " " + p.grad;
            op.value = p.id;
            se.appendChild(op);
        })
        let btnNadji = document.createElement("button");
        btnNadji.className = "btnn";
        btnNadji.onclick=(ev)=>this.nadjiLetove(host,kontprva);
        btnNadji.innerHTML="Nadji";
        kontprva.appendChild(btnNadji);

        let t = document.createElement("div");
        t.className="divt";
        host.appendChild(t);
                
        let tabela = document.createElement("table");
        tabela.className="tabela";
        t.appendChild(tabela);

        var tabelahead = document.createElement("thead");
        tabela.appendChild(tabelahead);
        var tr = document.createElement("tr");
        tabelahead.appendChild(tr);

        var teloTabele = document.createElement("tbody");
        teloTabele.className="TabelaPodaci";
        tabela.appendChild(teloTabele);

        let th;
        var zag = ["Datum leta", "Vreme polaska", "Vreme dolaska", "broj slobodnih mesta"];
        zag.forEach(el=>{
            th = document.createElement("th");
            th.innerHTML = el;
            tr.appendChild(th);
        })
    }
    nadjiLetove(host,kontprva){
        let optionEl = kontprva.querySelector("select");
        var aerodrom = optionEl.options[optionEl.selectedIndex];
        this.crtajLetove(aerodrom.value, host);
    }
    crtajLetove(id, host){
        var listaLetova=[];
        fetch("https://localhost:5001/Let/PronadjiLetove/"+id)
        .then(p=>{
            var teloTabele = this.obrisiPrethodno();
            p.json().then(letovi=>{
                letovi.forEach(a=>{
                    var p = new Lett(a.id, a.brojMesta, a.datumLeta, a.vremePolaska, a.vremeDolaska);
                    listaLetova.push(p);
                    p.crtaj(teloTabele, p.id);
                })
                

                




            })
        })
    }
    obrisiPrethodno(){
        var teloTabele = document.querySelector(".TabelaPodaci");
        var roditelj = teloTabele.parentNode;
        roditelj.removeChild(teloTabele);

        teloTabele = document.createElement("tbody");
        teloTabele.className="TabelaPodaci";
        roditelj.appendChild(teloTabele);
        return teloTabele;
    }
    crtajDodaj(host){
        let h = document.createElement("h3");
        h.className = "naslovh";
        h.innerHTML = "Dodaj Let";
        host.appendChild(h);

        let l = document.createElement("label");
        l.innerHTML = "Aerodrom";
        host.appendChild(l);

        let se = document.createElement("select");
        se.className = "selekt";
        host.appendChild(se);

        let op;
        this.listaAerodroma.forEach(p=>{
            op = document.createElement("option");
            op.innerHTML = p.naziv + " " + p.grad;
            op.value = p.id;
            se.appendChild(op);
        })
        

        l = document.createElement("label");
        l.innerHTML = "Datum Leta";
        host.appendChild(l);

        var datum = document.createElement("input");
        datum.type = "text";
        datum.className = "datum1";
        host.appendChild(datum);

        l = document.createElement("label");
        l.innerHTML = "Vreme polaska";
        host.appendChild(l);

        var vreme1 = document.createElement("input");
        vreme1.type = "text";
        vreme1.className = "vreme1";
        host.appendChild(vreme1);

        l = document.createElement("label");
        l.innerHTML = "Vreme dolaska";
        host.appendChild(l);

        var vreme2 = document.createElement("input");
        vreme2.type = "text";
        vreme2.className = "vreme2";
        host.appendChild(vreme2);

        l = document.createElement("label");
        l.innerHTML = "Klasa";
        host.appendChild(l);

        var listaKlasa=[];

        fetch("https://localhost:5001/Klasa/PronadjiKlase")
        .then(p=>{
          p.json().then(klase=>{
             klase.forEach(klasa=>{
                 var p = new Klasa(klasa.id, klasa.naziv);
                 listaKlasa.push(p);
        })
        let se = document.createElement("select");
        se.className = "selekt2";
        host.appendChild(se);

        let op;
        listaKlasa.forEach(p=>{
            op = document.createElement("option");
            op.innerHTML = p.naziv;
            op.value = p.id;
            se.appendChild(op);
        })
        let optionEl2 = this.kont.querySelector(".selekt2");
        var klasa2 = optionEl2.options[optionEl2.selectedIndex];

        let dugme3 = document.createElement("button");
        dugme3.className = "dugme3";
        dugme3.innerHTML = "Dodaj Let";
        dugme3.onclick=(ev)=>{
            let optionE = host.querySelector(".selekt");
            var aerodrom2 = optionE.options[optionE.selectedIndex];
            this.dodajj(aerodrom2.value, datum.value, vreme1.value, vreme2.value, klasa2.value, 100);
            
        }
        host.appendChild(dugme3);
        
    })
 })
}
dodajj(aID,datum,vreme1,vreme2,klasaID,brojMesta){
    fetch("https://localhost:5001/Let/DodajLet/"+aID+"/"+brojMesta+"/"+klasaID+"/"+datum+"/"+vreme1+"/"+vreme2,{method:'POST'});
}
}