import { Typography, Grid } from "@mui/material";
import { useFormContext } from "react-hook-form";
import AppTextInput from "../../app/components/AppTextInput";
import AppCheckbox from "../../app/components/AppCheckbox";

export default function AddressForm() {
  const {control, formState} = useFormContext();
  return (
    <>
      <Typography variant="h6" gutterBottom>
        Teslimat adresi
      </Typography>
      <Grid container spacing={3}>
        <Grid item xs={12} sm={12}>
          <AppTextInput control={control} name='fullName' label="Ad Soyad" />
        </Grid>
        <Grid item xs={12}>
          <AppTextInput control={control} name='address1' label="Adres satırı" />
        </Grid>
        <Grid item xs={12}>
          <AppTextInput control={control} name='address2' label="Adres satırı 2" />
        </Grid>
        <Grid item xs={12} sm={6}>
          <AppTextInput control={control} name='city' label="Şehir" />
        </Grid>
        <Grid item xs={12} sm={6}>
          <AppTextInput control={control} name='state' label="İlçe/Bölge" />
        </Grid>
        <Grid item xs={12} sm={6}>
          <AppTextInput control={control} name='zip' label="Posta Kodu" />
        </Grid>
        <Grid item xs={12} sm={6}>
          <AppTextInput control={control} name='country' label="Ülke" />
        </Grid>
        <Grid item xs={12}>
          <AppCheckbox 
            disabled={!formState.isDirty}
            name='saveAddress'
            label='Ödeme detayları için bu adresi kullanın.' 
            control={control} />
        </Grid>
      </Grid>
    </>
  );
}