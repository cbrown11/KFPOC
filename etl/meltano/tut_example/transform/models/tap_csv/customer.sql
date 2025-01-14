{{
  config(
    materialized='table'
  )
}}

with base as (
    select *
    from {{ source('tap_csv', 'raw_customers') }}
)
select *
from base
