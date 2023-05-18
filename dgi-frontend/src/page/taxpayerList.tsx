import { useEffect, useState } from "react";
import Table from "../components/Table";
import { http } from "../services/services";
import { Taxpayer } from "../model/taxpayer";


const TaxpayerList = () => {
    const [taxpayers, setTaxpayers] = useState<Taxpayer[]>([]);
    
    const getDataTable = async() => {
        const { data } = await http.get("/Taxpayers");
        
        setTaxpayers(data);
        
    }

    useEffect(() => { 
        getDataTable(); 
    }, []); 
    
    return(
        <>
            <Table taxpayers={taxpayers} /> 
        </>
    );
}

export default TaxpayerList