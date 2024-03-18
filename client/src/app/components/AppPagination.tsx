import { Box, Typography, Pagination } from "@mui/material";
import { MetaData } from "../models/pagination";
import { red } from "@mui/material/colors";

interface Props {
    metaData: MetaData;
    onPageChange: (page: number) => void;
}

export default function AppPagination({metaData, onPageChange}: Props){
    const {currentPage, totalCount, totalPages, pageSize} = metaData;
    return (
        <Box display='flex' justifyContent='space-between' alignItems='center'>
              <Typography>
                {totalCount} üründen {(currentPage-1)*pageSize+1}-
                {currentPage*pageSize > totalCount
                 ? totalCount 
                 : currentPage * pageSize} arası görüntüleniyor.
              </Typography>
              <Pagination
                sx={{color: red[600]}}
                size='large'
                count={totalPages}
                page={currentPage}
                onChange={(_e, page) => onPageChange(page)}
              />
            </Box>
    )
}