using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookManager : Singleton<CookManager>
{

    public Message messageText;
    public CropData curCropData;
    public MaterialData curMaterialData;
    //public ItemData itemData;

    public FoodData curFoodData;
    public FoodData[] foodDatas;

    public Image curCropImage;
    public Image curMatImage;
    public Image curFoodImage;
    public Sprite nullImage;

    private string combinedName;


    public List<CropData> cropList = new List<CropData>();
    public List<MaterialData> matList = new List<MaterialData>();
    public List<CoalData> coalList = new List<CoalData>();
    public int coalNum = 0;

    [SerializeField] int cNum = 0;
    [SerializeField] int mNum = 0;
    private void Awake() {
        _instance = this;
    }

    //Crop 종류: Carrot, Cabbage, Watermelon, Pumpkin,  Sunflower, Wheat
    //Material 종류: Oil, Flour
    //Food 종류: Stew, Soup, Cookie, Cupcake
//    string[] CropGroup = {"Carrot", "Cabbage", "Watermelon", "Pumpkin", "Sunflower", "Wheat"};
  //  string[] MaterialGroup = {"Oil", "Flour", "Sauce"};
    string[] Combined = {"CarrotOil", "CabbageOil", "WatermelonOil", "PumpkinOil", "SunflowerOil", "WheatOil"
    ,"CarrotFlour", "CabbageFlour", "WatermelonFlour", "PumpkinFlour", "SunflowerFlour", "WheatFlour"
    ,"CarrotSauce", "CabbageSauce", "WatermelonSauce", "PumpkinSauce", "SunflowerSauce", "WheatSauce"};

    string[] FoodGroup = {"Stew", "Soup", "Cookie", "Cupcake"};


    //StorageManager의 ItemList에서 cropdata만 Croplist에 집어넣는다.
    public void ClassifyDatas(ItemData data){

       // cropList.RemoveAll();

        if(data.itemType == ItemData.ItemType.CROP){
            cropList.Add((CropData)data);
        }

        if(data.itemType == ItemData.ItemType.MATERIAL){
            matList.Add((MaterialData)data);
        }

        if(data.itemType == ItemData.ItemType.COAL){
            coalList.Add((CoalData)data);
            coalNum += 1;
        }
        else{

        }




    }


    public void CropShow(){
        if(cropList.Count != 0){
            curCropData = cropList[cNum];
            curCropImage.sprite = cropList[cNum].icon;
        }
        else{
            curCropData = null;
            curCropImage.sprite = nullImage;

        }




    }

    public void MaterialShow(){
        if(matList.Count != 0){
            curMaterialData = matList[mNum];
            curMatImage.sprite = matList[mNum].icon;
        }
        else{
            curMaterialData = null;
            curMatImage.sprite = nullImage;

        }


    }

    public void FoodShow(){
        if(curFoodData != null){
            curFoodImage.sprite = curFoodData.icon;

        }
    }

    //버튼 조작
    public void PrevCrop(){
        if(cNum > 0){
            cNum -= 1;
        }
        else{
            cNum = cropList.Count - 1;
        }
        CropShow();

        
    }
    public void NextCrop(){
        if(cNum < cropList.Count - 1){
            cNum += 1;
        }
        else{
            cNum = 0;
        }
        CropShow();

    }
    public void PrevMat(){
       if(mNum > 0){
            mNum -= 1;
        }
        else{
            mNum = matList.Count - 1;
        }   
        MaterialShow();     
    }
    public void NextMat(){
        if(mNum < matList.Count - 1){
            mNum += 1;
        }
        else{
            mNum = 0;
        }        
        MaterialShow();
    }



//Cook 버튼을 눌렀을 때 Coal이 하나 차감되며 요리가 완성됨
    public void Cook(){

       if(cropList.Count == 0 || matList.Count == 0){
        messageText.NotEnoughIngredients();
        }
        else{

            if(coalNum == 0){
                messageText.NoCoal();
            }
            else{

                combinedName = curCropData.name + curMaterialData.name;

                if(combinedName.Contains("Oil")){
                    curFoodData = foodDatas[0];
                }

                if(combinedName.Contains("Flour")){
                    curFoodData = foodDatas[3];

                }

                if(combinedName.Contains("Sauce")){
                    curFoodData = foodDatas[2];

                }



                FoodShow();

                //요리 연성
                coalNum -= 1;
                StorageManager.Instance.RemoveNum(coalList[0]);
                coalList.Remove(coalList[0]);
                RemoveCurData();

                //요리 인벤토리에 넣어주기
                if(StorageManager.Instance.AddNum(curFoodData) == false){

                }
                else{

                }

            }
            



            //사용된 아이템 각각 제거
        }
    }

    public void RemoveCurData(){
        if(curFoodData != null){
            StorageManager.Instance.RemoveNum(cropList[cNum]);
            StorageManager.Instance.RemoveNum(matList[mNum]);
         
            cropList.Remove(cropList[cNum]);
            matList.Remove(matList[mNum]);
            if(cNum == 0){

            }
            else{
                cNum -= 1;
            }
            if(mNum == 0){
                

            }
            else{
                mNum -= 1;
            }
            StartCoroutine(ChangeImage());
           

        }
        if(cropList.Count == 0 || matList.Count == 0){

        }


    }

    IEnumerator ChangeImage(){
        yield return new WaitForSeconds(1f);
        CropShow();
        MaterialShow();
        RemoveFoodImage();
    }


    public void RemoveFoodImage(){
            curFoodData =null;
            curFoodImage.sprite = nullImage;
    }

}
