import { FormControl, FormLabel, RadioGroup, FormControlLabel, Radio } from "@mui/material";

interface Props {
    options: any[];
    onChange: (event: any) => void;
    selectedValue: string;
}

export default function RadioButtonGroup({options, onChange, selectedValue}: Props){
    return (
        <FormControl component="fieldset">
                <FormLabel component="legend">Sıralama Seçenekleri</FormLabel>
                  <RadioGroup onChange={onChange} value={selectedValue} sx={{ my: 1 }}>
                    {options.map(({value, label}) => (
                      <FormControlLabel value={value} control={<Radio />} label={label} key={value} />
                    ))}
                  </RadioGroup>
              </FormControl>
    )
}