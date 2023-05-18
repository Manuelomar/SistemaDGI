import { useParams } from 'react-router'
import { http } from '../services/services'
import { useState, useEffect } from 'react'
import { TaxpayerTotalItbis } from '../model/taxpayerTotalItbis'
import TableDetails from '../components/tableDetails'

export const TaxpayerDetail = () => {
  const {id} = useParams()

  const [taxpayer, setTaxpayer]= useState<TaxpayerTotalItbis | null>(null);

  useEffect(() => {
    const getDataById = async()=>{
      const {data}= await http.getById("/Taxpayers/getReceipt",id!)
      setTaxpayer(data);
    }
    getDataById();
  }, [])

  console.log(taxpayer)

  if(taxpayer == null || taxpayer == undefined) return <h1>Loading</h1>

  return (
    <>
      {taxpayer && <TableDetails taxpayerTotal={taxpayer} />}
    </>
  )
}