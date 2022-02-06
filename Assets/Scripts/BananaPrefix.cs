using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BananaPrefix : MonoBehaviour
{
    
    // number is the thing you want to convert to abbrviation, bool is the type of suffix you want, (true is big, false is small)
    public string Suffix(double number, string precision = "0.0", bool bigSuffix = false, string onedigitprecision = "0")
    {
        if (bigSuffix)
        {
            if (number >= 1e306)
            {
                return ((number / 1e306).ToString(precision + " Uncentillion"));
            }
            if (number >= 1e303)
            {
                return ((number / 1e303).ToString(precision + " Centillion"));
            }
            if (number >= 1e300)
            {
                return ((number / 1e300).ToString(precision + " Novemonagintillion"));
            }
            if (number >= 1e297)
            {
                return ((number / 1e297).ToString(precision + " Octononagintillion"));
            }
            if (number >= 1e294)
            {
                return ((number / 1e294).ToString(precision + " Septenonagintillion"));
            }
            if (number >= 1e291)
            {
                return ((number / 1e291).ToString(precision + " Senonagintillion"));
            }
            if (number >= 1e288)
            {
                return ((number / 1e288).ToString(precision + " Quinnonagintillion"));
            }
            if (number >= 1e285)
            {
                return ((number / 1e285).ToString(precision + " Trenonagintillion"));
            }
            if (number >= 1e282)
            {
                return ((number / 1e282).ToString(precision + " Trenonagintillion"));
            }
            if (number >= 1e279)
            {
                return ((number / 1e279).ToString(precision + " Duononagintillion"));
            }
            if (number >= 1e276)
            {
                return ((number / 1e276).ToString(precision + " Unnonagintillion"));
            }
            if (number >= 1e273)
            {
                return ((number / 1e273).ToString(precision + " Nonagintillion"));
            }
            if (number >= 1e270)
            {
                return ((number / 1e270).ToString(precision + " Novemoctogintillion"));
            }
            if (number >= 1e267)
            {
                return ((number / 1e267).ToString(precision + " Octooctogintillion"));
            }
            if (number >= 1e264)
            {
                return ((number / 1e264).ToString(precision + " Septemoctogintillion"));
            }
            if (number >= 1e261)
            {
                return ((number / 1e261).ToString(precision + " Sexoctogintillion"));
            }
            if (number >= 1e258)
            {
                return ((number / 1e258).ToString(precision + " Quinoctogintillion"));
            }
            if (number >= 1e255)
            {
                return ((number / 1e255).ToString(precision + " Quattuoroctogintillion"));
            }
            if (number >= 1e252)
            {
                return ((number / 1e252).ToString(precision + " Treoctogintillion"));
            }
            if (number >= 1e249)
            {
                return ((number / 1e249).ToString(precision + " Duooctogintillion"));
            }
            if (number >= 1e246)
            {
                return ((number / 1e246).ToString(precision + " Unoctogintillion"));
            }
            if (number >= 1e243)
            {
                return ((number / 1e243).ToString(precision + " Octogintillion"));
            }
            if (number >= 1e240)
            {
                return ((number / 1e240).ToString(precision + " Novemseptuagintillion"));
            }
            if (number >= 1e237)
            {
                return ((number / 1e237).ToString(precision + " Octoseptuagintillion"));
            }
            if (number >= 1e234)
            {
                return ((number / 1e234).ToString(precision + " Septenseptuagintillion"));
            }
            if (number >= 1e231)
            {
                return ((number / 1e231).ToString(precision + " Seseptuagintillion"));
            }
            if (number >= 1e228)
            {
                return ((number / 1e228).ToString(precision + " Quinseptuagintillion"));
            }
            if (number >= 1e225)
            {
                return ((number / 1e225).ToString(precision + " Quattuorseptuagintillion"));
            }
            if (number >= 1e222)
            {
                return ((number / 1e222).ToString(precision + " Treseptuagintillion"));
            }
            if (number >= 1e219)
            {
                return ((number / 1e219).ToString(precision + " Duoseptuagintillion"));
            }
            if (number >= 1e216)
            {
                return ((number / 1e216).ToString(precision + " Unseptuagintillion"));
            }
            if (number >= 1e213)
            {
                return ((number / 1e213).ToString(precision + " Septuagintillion"));
            }
            if (number >= 1e210)
            {
                return ((number / 1e210).ToString(precision + " Novemsexagintillion"));
            }
            if (number >= 1e207)
            {
                return ((number / 1e207).ToString(precision + " Octosexagintillion"));
            }
            if (number >= 1e204)
            {
                return ((number / 1e204).ToString(precision + " Septensexagintillion"));
            }
            if (number >= 1e201)
            {
                return ((number / 1e201).ToString(precision + " Sesexagintillion"));
            }
            if (number >= 1e198)
            {
                return ((number / 1e198).ToString(precision + " Quinsexagintillion"));
            }
            if (number >= 1e195)
            {
                return ((number / 1e195).ToString(precision + " Quattuorsexagintillion"));
            }
            if (number >= 1e192)
            {
                return ((number / 1e192).ToString(precision + " Tresexagintillion"));
            }
            if (number >= 1e189)
            {
                return ((number / 1e189).ToString(precision + " Duosexagintillion"));
            }
            if (number >= 1e186)
            {
                return ((number / 1e186).ToString(precision + " Unsexagintillion"));
            }
            if (number >= 1e183)
            {
                return ((number / 1e183).ToString(precision + " Sexagintillion"));
            }
            if (number >= 1e180)
            {
                return ((number / 1e180).ToString(precision + " Novemquinquagintillion"));
            }
            if (number >= 1e177)
            {
                return ((number / 1e177).ToString(precision + " Octoquinquagintillion"));
            }
            if (number >= 1e174)
            {
                return ((number / 1e174).ToString(precision + " Septenquinquagintillion"));
            }
            if (number >= 1e171)
            {
                return ((number / 1e171).ToString(precision + " Sesquinquagintillion"));
            }
            if (number >= 1e168)
            {
                return ((number / 1e168).ToString(precision + " Quinquinquagintillion"));
            }
            if (number >= 1e165)
            {
                return ((number / 1e165).ToString(precision + " Quattuorquinquagintillion"));
            }
            if (number >= 1e162)
            {
                return ((number / 1e162).ToString(precision + " Tresquinquagintillion"));
            }
            if (number >= 1e159)
            {
                return ((number / 1e159).ToString(precision + " Duoquinquagintillion"));
            }
            if (number >= 1e156)
            {
                return ((number / 1e156).ToString(precision + " Unquinquagintillion"));
            }
            if (number >= 1e153)
            {
                return ((number / 1e153).ToString(precision + " Quinquagintillion"));
            }
            if (number >= 1e150)
            {
                return ((number / 1e150).ToString(precision + " Novemquadragintillion"));
            }
            if (number >= 1e147)
            {
                return ((number / 1e147).ToString(precision + " Octoquadragintillion"));
            }
            if (number >= 1e144)
            {
                return ((number / 1e144).ToString(precision + " Septenquadragintillion"));
            }
            if (number >= 1e141)
            {
                return ((number / 1e141).ToString(precision + " Sesquadragintillion"));
            }
            if (number >= 1e138)
            {
                return ((number / 1e138).ToString(precision + " Quinquadragintillion"));
            }
            if (number >= 1e135)
            {
                return ((number / 1e135).ToString(precision + " Quattuorquadragintillion"));
            }
            if (number >= 1e132)
            {
                return ((number / 1e132).ToString(precision + " Tresquadragintillion"));
            }
            if (number >= 1e129)
            {
                return ((number / 1e129).ToString(precision + " Duoquadragintillion"));
            }
            if (number >= 1e126)
            {
                return ((number / 1e126).ToString(precision + " Unquadragintillion"));
            }
            if (number >= 1e123)
            {
                return ((number / 1e123).ToString(precision + " Quadragintillion"));
            }
            if (number >= 1e120)
            {
                return ((number / 1e120).ToString(precision + " Novemtrigintillion"));
            }
            if (number >= 1e117)
            {
                return ((number / 1e117).ToString(precision + " Octotrigintillion"));
            }
            if (number >= 1e114)
            {
                return ((number / 1e114).ToString(precision + " Septentrigintillion"));
            }
            if (number >= 1e111)
            {
                return ((number / 1e111).ToString(precision + " Sestrigintillion"));
            }
            if (number >= 1e108)
            {
                return ((number / 1e108).ToString(precision + " Quintrigintillion"));
            }
            if (number >= 1e105)
            {
                return ((number / 1e105).ToString(precision + " Quattuortrigintillion"));
            }
            if (number >= 1e102)
            {
                return ((number / 1e102).ToString(precision + " Trestrigintillion"));
            }
            if (number >= 1e99)
            {
                return ((number / 1e99).ToString(precision + " Duotrigintillion"));
            }
            if (number >= 1e96)
            {
                return ((number / 1e96).ToString(precision + " Untrigintillion"));
            }
            if (number >= 1e93)
            {
                return ((number / 1e93).ToString(precision + " Trigintillion"));
            }
            if (number >= 1e90)
            {
                return ((number / 1e90).ToString(precision + " Novemvigintillion"));
            }
            if (number >= 1e87)
            {
                return ((number / 1e87).ToString(precision + " Octovigintilion"));
            }
            if (number >= 1e84)
            {
                return ((number / 1e84).ToString(precision + " Septemvigintillion"));
            }
            if (number >= 1e81)
            {
                return ((number / 1e81).ToString(precision + " Sesvigintillion"));
            }
            if (number >= 1e78)
            {
                return ((number / 1e78).ToString(precision + " Quinvigintillion"));
            }
            if (number >= 1e75)
            {
                return ((number / 1e75).ToString(precision + " Quattuorvigintillion	"));
            }
            if (number >= 1e72)
            {
                return ((number / 1e72).ToString(precision + " Tresvigintillion"));
            }
            if (number >= 1e69)
            {
                return ((number / 1e69).ToString(precision + " Duovigintillion"));
            }
            if (number >= 1e66)
            {
                return ((number / 1e66).ToString(precision + " Unvigintillion"));
            }
            if (number >= 1e63)
            {
                return ((number / 1e63).ToString(precision + " Vigintillion"));
            }
            if (number >= 1e60)
            {
                return ((number / 1e60).ToString(precision + " Novemdecillion"));
            }
            if (number >= 1e57)
            {
                return ((number / 1e57).ToString(precision + " Octodecillion"));
            }
            if (number >= 1e54)
            {
                return ((number / 1e54).ToString(precision + " Septendecillion"));
            }
            if (number >= 1e51)
            {
                return ((number / 1e51).ToString(precision + " Sedecillion"));
            }
            if (number >= 1e48)
            {
                return ((number / 1e48).ToString(precision + " Quindecillion"));
            }
            if (number >= 1e45)
            {
                return ((number / 1e45).ToString(precision + " Quattuordecillion"));
            }
            if (number >= 1e42)
            {
                return ((number / 1e42).ToString(precision + " Tredecillion"));
            }
            if (number >= 1e39)
            {
                return ((number / 1e39).ToString(precision + " Duodecillion"));
            }
            if (number >= 1e36)
            {
                return ((number / 1e36).ToString(precision + " Undecillion"));
            }
            if (number >= 1e33)
            {
                return ((number / 1e33).ToString(precision + " Decillion"));
            }
            if (number >= 1e30)
            {
                return ((number / 1e30).ToString(precision + " Nonillion"));
            }
            if (number >= 1e27)
            {
                return ((number / 1e27).ToString(precision + " Octillion"));
            }
            if (number >= 1e24)
            {
                return ((number / 1e24).ToString(precision + " Septillion"));
            }
            if (number >= 1e21)
            {
                return ((number / 1e21).ToString(precision + " Sextillion"));
            }
            if (number >= 1e18)
            {
                return ((number / 1e18).ToString(precision + " Quintillion"));
            }
            if (number >= 1e15)
            {
                return ((number / 1e15).ToString(precision + " Quadrillion"));
            }
            if (number >= 1e12)
            {
                return ((number / 1e12).ToString(precision + " Trillion"));
            }
            if (number >= 1e9)
            {
                return ((number / 1e9).ToString(precision + " Billion"));
            }
            if (number >= 1e6)
            {
                return ((number / 1e6).ToString(precision + " Million"));
            }
            if (number >= 1e3)
            {
                return ((number / 1e3).ToString(precision + " Thousand"));
            }
            else
            {
                return (number.ToString(onedigitprecision));
            }
        }
        else
        { // smaller suffic that will fit on buttons.
            if (number >= 1e306)
            {
                return ((number / 1e306).ToString(precision + " UNCENT"));
            }
            if (number >= 1e303)
            {
                return ((number / 1e303).ToString(precision + " CENT"));
            }
            if (number >= 1e300)
            {
                return ((number / 1e300).ToString(precision + " NONONGNTL"));
            }
            if (number >= 1e297)
            {
                return ((number / 1e297).ToString(precision + " OTNONGNTL"));
            }
            if (number >= 1e294)
            {
                return ((number / 1e294).ToString(precision + " SPNONGNTL"));
            }
            if (number >= 1e291)
            {
                return ((number / 1e291).ToString(precision + " SXNONGNTL"));
            }
            if (number >= 1e288)
            {
                return ((number / 1e288).ToString(precision + " QNNONGNTL"));
            }
            if (number >= 1e285)
            {
                return ((number / 1e285).ToString(precision + " QTNONGNTL"));
            }
            if (number >= 1e282)
            {
                return ((number / 1e282).ToString(precision + " TNONGNTL"));
            }
            if (number >= 1e279)
            {
                return ((number / 1e279).ToString(precision + " DNONGNTL"));
            }
            if (number >= 1e276)
            {
                return ((number / 1e276).ToString(precision + " UNONGNTL"));
            }
            if (number >= 1e273)
            {
                return ((number / 1e273).ToString(precision + " NONGNTL"));
            }
            if (number >= 1e270)
            {
                return ((number / 1e270).ToString(precision + " NVOTGNTL"));
            }
            if (number >= 1e267)
            {
                return ((number / 1e267).ToString(precision + " OTOTGNTL"));
            }
            if (number >= 1e264)
            {
                return ((number / 1e264).ToString(precision + " SPOTGNTL"));
            }
            if (number >= 1e261)
            {
                return ((number / 1e261).ToString(precision + " SXOTGNTL"));
            }
            if (number >= 1e258)
            {
                return ((number / 1e258).ToString(precision + " QNOTGNTL"));
            }
            if (number >= 1e255)
            {
                return ((number / 1e255).ToString(precision + " QTOTGNTL"));
            }
            if (number >= 1e252)
            {
                return ((number / 1e252).ToString(precision + " TOTGNTL"));
            }
            if (number >= 1e249)
            {
                return ((number / 1e249).ToString(precision + " DOTGNTL"));
            }
            if (number >= 1e246)
            {
                return ((number / 1e246).ToString(precision + " UOTGNTL"));
            }
            if (number >= 1e243)
            {
                return ((number / 1e243).ToString(precision + " OTGNTL"));
            }
            if (number >= 1e240)
            {
                return ((number / 1e240).ToString(precision + " NVSPTGNTL"));
            }
            if (number >= 1e237)
            {
                return ((number / 1e237).ToString(precision + " OSPTGNTL"));
            }
            if (number >= 1e234)
            {
                return ((number / 1e234).ToString(precision + " SPSPTGNTL"));
            }
            if (number >= 1e231)
            {
                return ((number / 1e231).ToString(precision + " SXSPTGNTL"));
            }
            if (number >= 1e228)
            {
                return ((number / 1e228).ToString(precision + " QNSPTGNTL"));
            }
            if (number >= 1e225)
            {
                return ((number / 1e225).ToString(precision + " QTSPTGNTL"));
            }
            if (number >= 1e222)
            {
                return ((number / 1e222).ToString(precision + " TSPTGNTL"));
            }
            if (number >= 1e219)
            {
                return ((number / 1e219).ToString(precision + " DSPTGNTL"));
            }
            if (number >= 1e216)
            {
                return ((number / 1e216).ToString(precision + " USPTGNTL"));
            }
            if (number >= 1e213)
            {
                return ((number / 1e213).ToString(precision + " SPTGNTL"));
            }
            if (number >= 1e210)
            {
                return ((number / 1e210).ToString(precision + " NVSXGNTL"));
            }
            if (number >= 1e207)
            {
                return ((number / 1e207).ToString(precision + " OSXGNTL"));
            }
            if (number >= 1e204)
            {
                return ((number / 1e204).ToString(precision + " SPSXGNTL"));
            }
            if (number >= 1e201)
            {
                return ((number / 1e201).ToString(precision + " SXSXGNTL"));
            }
            if (number >= 1e198)
            {
                return ((number / 1e198).ToString(precision + " QNSXGNTL"));
            }
            if (number >= 1e195)
            {
                return ((number / 1e195).ToString(precision + " QTSXGNTL"));
            }
            if (number >= 1e192)
            {
                return ((number / 1e192).ToString(precision + " TSXGNTL"));
            }
            if (number >= 1e189)
            {
                return ((number / 1e189).ToString(precision + " DSXGNTL"));
            }
            if (number >= 1e186)
            {
                return ((number / 1e186).ToString(precision + " USXGNTL"));
            }
            if (number >= 1e183)
            {
                return ((number / 1e183).ToString(precision + " SXGNTL"));
            }
            if (number >= 1e180)
            {
                return ((number / 1e180).ToString(precision + " NQQGNT"));
            }
            if (number >= 1e177)
            {
                return ((number / 1e177).ToString(precision + " OQQGNT"));
            }
            if (number >= 1e174)
            {
                return ((number / 1e174).ToString(precision + " SpQGNT"));
            }
            if (number >= 1e171)
            {
                return ((number / 1e171).ToString(precision + " sxQGNT"));
            }
            if (number >= 1e168)
            {
                return ((number / 1e168).ToString(precision + " QnQGNT"));
            }
            if (number >= 1e165)
            {
                return ((number / 1e165).ToString(precision + " qdQGNT"));
            }
            if (number >= 1e162)
            {
                return ((number / 1e162).ToString(precision + " tQGNT"));
            }
            if (number >= 1e159)
            {
                return ((number / 1e159).ToString(precision + " dQGNT"));
            }
            if (number >= 1e156)
            {
                return ((number / 1e156).ToString(precision + " uQGNT"));
            }
            if (number >= 1e153)
            {
                return ((number / 1e153).ToString(precision + " qQGNT"));
            }
            if (number >= 1e150)
            {
                return ((number / 1e150).ToString(precision + " NQDDr"));
            }
            if (number >= 1e147)
            {
                return ((number / 1e147).ToString(precision + " OQDDr"));
            }
            if (number >= 1e144)
            {
                return ((number / 1e144).ToString(precision + " SpQDR"));
            }
            if (number >= 1e141)
            {
                return ((number / 1e141).ToString(precision + " sxQDR"));
            }
            if (number >= 1e138)
            {
                return ((number / 1e138).ToString(precision + " QnQDR"));
            }
            if (number >= 1e135)
            {
                return ((number / 1e135).ToString(precision + " qdQDR"));
            }
            if (number >= 1e132)
            {
                return ((number / 1e132).ToString(precision + " tQDR"));
            }
            if (number >= 1e129)
            {
                return ((number / 1e129).ToString(precision + " dQDR"));
            }
            if (number >= 1e126)
            {
                return ((number / 1e126).ToString(precision + " uQDR"));
            }
            if (number >= 1e123)
            {
                return ((number / 1e123).ToString(precision + " QdDR"));
            }
            if (number >= 1e120)
            {
                return ((number / 1e120).ToString(precision + " NoTG"));
            }
            if (number >= 1e117)
            {
                return ((number / 1e117).ToString(precision + " OcTG"));
            }
            if (number >= 1e114)
            {
                return ((number / 1e114).ToString(precision + " SpTG"));
            }
            if (number >= 1e111)
            {
                return ((number / 1e111).ToString(precision + " ssTG"));
            }
            if (number >= 1e108)
            {
                return ((number / 1e108).ToString(precision + " QnTG"));
            }
            if (number >= 1e105)
            {
                return ((number / 1e105).ToString(precision + " qtTG"));
            }
            if (number >= 1e102)
            {
                return ((number / 1e102).ToString(precision + " tsTG"));
            }
            if (number >= 1e99)
            {
                return ((number / 1e99).ToString(precision + " DTG"));
            }
            if (number >= 1e96)
            {
                return ((number / 1e96).ToString(precision + " UTG"));
            }
            if (number >= 1e93)
            {
                return ((number / 1e93).ToString(precision + " TGN"));
            }
            if (number >= 1e90)
            {
                return ((number / 1e90).ToString(precision + " NVG"));
            }
            if (number >= 1e87)
            {
                return ((number / 1e87).ToString(precision + " OVG"));
            }
            if (number >= 1e84)
            {
                return ((number / 1e84).ToString(precision + " SPG"));
            }
            if (number >= 1e81)
            {
                return ((number / 1e81).ToString(precision + " QnV"));
            }
            if (number >= 1e78)
            {
                return ((number / 1e78).ToString(precision + " QnV"));
            }
            if (number >= 1e75)
            {
                return ((number / 1e75).ToString(precision + " qtV"));
            }
            if (number >= 1e72)
            {
                return ((number / 1e72).ToString(precision + " TVg"));
            }
            if (number >= 1e69)
            {
                return ((number / 1e69).ToString(precision + " DVg"));
            }
            if (number >= 1e66)
            {
                return ((number / 1e66).ToString(precision + " UVg"));
            }
            if (number >= 1e63)
            {
                return ((number / 1e63).ToString(precision + " Vgn"));
            }
            if (number >= 1e60)
            {
                return ((number / 1e60).ToString(precision + " NvD"));
            }
            if (number >= 1e57)
            {
                return ((number / 1e57).ToString(precision + " OcD"));
            }
            if (number >= 1e54)
            {
                return ((number / 1e54).ToString(precision + " SpD"));
            }
            if (number >= 1e51)
            {
                return ((number / 1e51).ToString(precision + " sxD"));
            }
            if (number >= 1e48)
            {
                return ((number / 1e48).ToString(precision + " QnD"));
            }
            if (number >= 1e45)
            {
                return ((number / 1e45).ToString(precision + " qdD"));
            }
            if (number >= 1e42)
            {
                return ((number / 1e42).ToString(precision + " tdD"));
            }
            if (number >= 1e39)
            {
                return ((number / 1e39).ToString(precision + " DD"));
            }
            if (number >= 1e36)
            {
                return ((number / 1e36).ToString(precision + " Ud"));
            }
            if (number >= 1e33)
            {
                return ((number / 1e33).ToString(precision + " De"));
            }
            if (number >= 1e30)
            {
                return ((number / 1e30).ToString(precision + "N"));
            }
            if (number >= 1e27)
            {
                return ((number / 1e27).ToString(precision + "O"));
            }
            if (number >= 1e24)
            {
                return ((number / 1e24).ToString(precision + "Sp"));
            }
            if (number >= 1e21)
            {
                return ((number / 1e21).ToString(precision + "Sx"));
            }
            if (number >= 1e18)
            {
                return ((number / 1e18).ToString(precision + "Qn"));
            }
            if (number >= 1e15)
            {
                return ((number / 1e15).ToString(precision + "Qd"));
            }
            if (number >= 1e12)
            {
                return ((number / 1e12).ToString(precision + "T"));
            }
            if (number >= 1e9)
            {
                return ((number / 1e9).ToString(precision + "B"));
            }
            if (number >= 1e6)
            {
                return ((number / 1e6).ToString(precision + "M"));
            }
            if (number >= 1e3)
            {
                return ((number / 1e3).ToString(precision + "K"));
            }
            else
            {
                return (number.ToString(onedigitprecision));
            }
        }
    }
}