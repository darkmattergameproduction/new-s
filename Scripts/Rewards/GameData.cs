using UnityEngine;

public static class GameData
{
  
  private static int coin = PlayerManager.numberOfCoins;
    private static int _gems = 0;
    private static int _metals = 0;

    // The static Constructor is the best place
    // to load already saved data in a file or in PlayerPrefs.
    static GameData()
    {
        int coin = PlayerManager.numberOfCoins;
        PlayerManager.numberOfCoins = PlayerPrefs.GetInt("numberOfCoins");

       
        _gems = PlayerPrefs.GetInt("Gems", 0);
        _metals = PlayerPrefs.GetInt("Metals", 0);
    }


    // set{ PlayerPrefs.SetInt ( "Coins", (_coins = value) ); }
    //
    // is equivalent to :
    // 
    // set {
    //    _coins = value;
    //    PlayerPrefs.SetInt ( "Coins", _coins);
    // }
    public static int Coins
    {
        get { return  coin ; }
        set { PlayerPrefs.SetInt("Coins", PlayerManager.numberOfCoins); }
    }

    public static int Gems
    {
        get { return _gems; }
        set { PlayerPrefs.SetInt("Gems", (_gems = value)); }
    }
    public static int Metals
    {
        get { return _metals; }
        set { PlayerPrefs.SetInt("Metals", (_metals = value)); }
    }
}
