export class Lett{
    constructor(id, brojMesta, datumLeta, vremePolaska, vremeDolaska){
        this.id = id;
        this.brojMesta = brojMesta;
        this.datumLeta = datumLeta;
        this.vremePolaska = vremePolaska;
        this.vremeDolaska = vremeDolaska;
        this.kont = null;
    }
    crtaj(host, letID){
        var tr = document.createElement("tr");
        host.appendChild(tr);

        this.kont = tr;

        var el = document.createElement("td");
        el.innerHTML = this.datumLeta;
        tr.appendChild(el);

        var el = document.createElement("td");
        el.innerHTML = this.vremePolaska;
        tr.appendChild(el);

        var el = document.createElement("td");
        el.innerHTML = this.vremeDolaska;
        tr.appendChild(el);

        var el = document.createElement("td");
        el.className = "mesto";
        el.innerHTML = this.brojMesta;
        tr.appendChild(el);

        let dugme = document.createElement("button");
        dugme.innerHTML = "Rezerviši";
        dugme.onclick=(ev)=>{
            this.rezervisi(letID);
        }
        tr.appendChild(dugme);

        let dugme2 = document.createElement("button");
        dugme2.innerHTML = "Obriši";
        dugme2.onclick=(ev)=>{
            this.obrisi(letID, host);
        }
        tr.appendChild(dugme2);
    }
    rezervisi(letID){
        if(this.brojMesta>0){
            fetch("https://localhost:5001/Let/IzmeniLet/"+letID, {method:'PUT'});
            this.brojMesta--;
            let mesto = this.kont.querySelector(".mesto");
            mesto.innerHTML = this.brojMesta;
        }
        else
        {
            alert("Nema vise mesta");
        }
    }
    obrisi(letID, host){
        fetch("https://localhost:5001/Let/IzbrisiLet/"+letID, {method:'DELETE'});
        host.removeChild(this.kont);
    }
}