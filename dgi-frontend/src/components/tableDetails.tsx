import { TaxpayerTotalItbis } from '../model/taxpayerTotalItbis';
import './Table.scss'; 
import { Link } from 'react-router-dom';
import Button from 'react-bootstrap/Button';

interface TableProps {
    taxpayerTotal: TaxpayerTotalItbis; // Nota que el nombre ahora es en singular, ya que no es un array
}

const TableDetails: React.FC<TableProps> = ({ taxpayerTotal }) => {

  console.log(taxpayerTotal)

  return (
    <div className='container'>
      <table className="tabla">
        <thead>
          <tr>
       <th>
        Cedula
       </th>
       <th>
        Ncf
       </th>
       <th>
        Monto
       </th>
       <th>
        ITbis
       </th>
          </tr>
        </thead>
        <tbody>
              {
               taxpayerTotal.taxReceipt?.map((receipt, index) => (
                 <tr key={index}>
                <td>{receipt.RncCedula}</td>
                <td>{receipt.ncf}</td>
                <td>{receipt.Monto}</td>
                <td>{receipt.itbis18}</td>
              </tr>
            ))
          } 
          <td>Total de Itbis</td>
          <td>{taxpayerTotal.totalItbis}</td>

        </tbody>
      </table>
      <Link to={`/`}>
        <Button variant="success">Volver</Button>
      </Link>
    </div>
  );
}

export default TableDetails;
