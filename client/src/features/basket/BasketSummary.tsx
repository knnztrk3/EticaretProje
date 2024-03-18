import { TableContainer, Paper, Table, TableBody, TableRow, TableCell } from "@mui/material";
import { currencyFormat } from "../../app/util/util";
import { useAppSelector } from "../../app/store/configureStore";

interface Props {
    subtotal?: number;
}

export default function BasketSummary({subtotal}: Props) {
    const {basket} = useAppSelector(state => state.basket);
    if (subtotal === undefined)
        subtotal = basket?.items.reduce((sum, item) => sum + (item.quantity * item.price), 0) ?? 0;
    const deliveryFee = subtotal > 75000 ? 0 : 15000;

    return (
        <>
            <TableContainer component={Paper} variant={'outlined'}>
                <Table>
                    <TableBody>
                        <TableRow>
                            <TableCell colSpan={2}>Ürünün Toplamı</TableCell>
                            <TableCell align="right">{currencyFormat(subtotal)}</TableCell>
                        </TableRow>
                        <TableRow>
                            <TableCell colSpan={2}>Kargo Toplam</TableCell>
                            <TableCell align="right">{currencyFormat(deliveryFee)}</TableCell>
                        </TableRow>
                        <TableRow>
                            <TableCell colSpan={2}>Toplam</TableCell>
                            <TableCell align="right">{currencyFormat(subtotal + deliveryFee)}</TableCell>
                        </TableRow>
                        <TableRow>
                            <TableCell colSpan={2}>Tahmini Teslim Süresi</TableCell>
                            <TableCell align="right">3 Gün</TableCell>
                        </TableRow>
                        <TableRow>
                            <TableCell>
                                <span style={{fontWeight: 'bold'}}>*750 TL ve Üzeri Kargo Bedava</span>
                            </TableCell>
                        </TableRow>
                    </TableBody>
                </Table>
            </TableContainer>
        </>
    )
}