Shader "Graph/Column2D"
{
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };
            
            uniform float4 _Colors [100];
            uniform float _Columns [100];
            uniform float _ColumnAmount;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                if(_ColumnAmount == 0) discard;
                float columnId = floor(i.uv.x*_ColumnAmount);
                if(i.uv.y > _Columns[columnId]) discard;
                fixed4 col = _Colors[columnId];
                return col;
            }
            ENDCG
        }
    }
}
