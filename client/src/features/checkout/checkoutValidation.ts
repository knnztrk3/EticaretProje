import * as yup from 'yup';

export const validationSchema = [
    //0 -> checkoutpage.tsx activeStep icin
    yup.object({
        fullName: yup.string().required('Ad soyad alanı gerekli'),
        address1: yup.string().required('Adres alanı gerekli'),
        address2: yup.string().required('Adres alanı gerekli'),
        city: yup.string().required('Şehir alanı gerekli'),
        state: yup.string().required('İlçe alanı gerekli'),
        zip: yup.string().required('Posta kodu alanı gerekli'),
        country: yup.string().required('Ülke alanı gerekli'),
    }),
    //1 -> checkoutpage.tsx activeStep icin
    yup.object(),
    //2 -> checkoutpage.tsx activeStep icin
    yup.object({
        nameOnCard: yup.string().required()
    }),
] 