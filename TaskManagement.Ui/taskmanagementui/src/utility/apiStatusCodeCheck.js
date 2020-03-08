const apiStatusCodeCheck = statusCode => {
  switch (statusCode) {
    case 400:
      return "مقادیر ورودی را چک کنید";
    case 401:
      return "خطا در اعتبار سنجی";
    case 500:
      return "خطای سرویس دهنده";
    default:
      return "خطای ناشناخته از سمت سرویس دهنده";
  }
};

export default apiStatusCodeCheck;
